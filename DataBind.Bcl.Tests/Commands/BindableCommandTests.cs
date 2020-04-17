using System;
using DataBind.Bcl.Commands;
using FluentAssertions.Execution;
using Moq;
using Xunit;
namespace DataBind.Bcl.Tests.Commands {

	public class BindableCommandTests {

		[Fact]
		public void BindableCommand_Throws_Error_When_Action_Is_Null() {

			Assert.Throws<ArgumentNullException>(
				() => {

					var command = new BindableCommand(null);

				}
			);

		}

		[Fact]
		public void BindableCommand_Throws_Error_When_Action_Is_Not_Null_And_Predicate_Is_Null() {

			var action = new Mock<Action>();

			Assert.Throws<ArgumentNullException>(
				() => {

					var command = new BindableCommand(action.Object, null);

				}
			);

		}

		[Fact]
		public void BindableCommand_Action_Is_Executed_Only_Once() {

			var action = new Mock<Action>();
			action.Setup(x => x());

			var command = new BindableCommand(action.Object);
			command.Execute();

			action.Verify(a => a(), Times.AtMostOnce());
		}

		[Fact]
		public void BindableCommand_CanExecuteAction_Is_Executed_Only_Once() {

			var action = new Mock<Action>();
			action.Setup(x => x());

			var canExecuteAction = new Mock<Func<bool>>();
			canExecuteAction.Setup(x => x()).Returns(false);

			var command = new BindableCommand(action.Object, canExecuteAction.Object);
			var actual = command.CanExecute();
			var expected = false;

			using (new AssertionScope()) { 
				canExecuteAction.Verify(a => a(), Times.AtMostOnce());
				Assert.Equal(expected, actual);
			}
		}
	}

}