using System;
using System.Threading;
using System.Threading.Tasks;
using Dolittle.Tenancy;
using Machine.Specifications;

namespace Dolittle.Execution.for_ExecutionContextManager
{
    public class when_getting_context_from_two_different_nested_thread_contexts : given.an_execution_context_manager
    {
        static TenantId first_tenant;
        static TenantId second_tenant;
        static TenantId first_result;
        static TenantId second_result;
        
        Because of = () =>
        {
            first_tenant = Guid.NewGuid();
            second_tenant = Guid.NewGuid();

            var first_manual_event = new ManualResetEvent(false);
            var second_manual_event = new ManualResetEvent(false);

            var first_thread = new Thread(() => 
            {
                execution_context_manager.CurrentFor(first_tenant);
                var first_nested_thread = new Thread(() => 
                {
                    first_result = new Guid(execution_context_manager.Current.Tenant.Value.ToByteArray());
                    first_manual_event.Set();
                });
                first_nested_thread.Start();
            });

            var second_thread = new Thread(() => 
            {
                execution_context_manager.CurrentFor(second_tenant);
                var second_nested_thread = new Thread(() => 
                {
                    second_result = new Guid(execution_context_manager.Current.Tenant.Value.ToByteArray());
                    second_manual_event.Set();
                });
                second_nested_thread.Start();
            });

            second_thread.Start();
            first_thread.Start();

            first_manual_event.WaitOne();
            second_manual_event.WaitOne();
        };

        It should_have_first_tenant_in_first_context = () => first_result.ShouldEqual(first_tenant);
        It should_have_second_tenant_in_second_context = () => second_result.ShouldEqual(second_tenant);
    }
}