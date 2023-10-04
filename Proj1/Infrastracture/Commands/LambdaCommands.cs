using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj1.Infrastracture.Commands.Base;
namespace Proj1.Infrastracture.Commands
{
    internal class LambdaCommands : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        public LambdaCommands(Action<object> Execute, Func<object, bool> CanExecute = null) {
            _Execute = Execute ?? throw new ArgumentException(nameof(Execute));
            _CanExecute = CanExecute;
        }
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execute(parameter);
    }
}
