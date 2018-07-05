using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{

    public class Operation : IOperation, IOperationTransient, IOperationScoped, IOperationSingleton, IOperationSingletonInstance
    {
        public Guid OperationId { get; set; }

        // コンストラクタで GUID を受け取る、提供されない場合は新規に GUID を作成
        public Operation() : this(Guid.NewGuid())
        {
        }
        public Operation(Guid id)
        {
            OperationId = id;
            Console.WriteLine(OperationId);
        }
    }
}
