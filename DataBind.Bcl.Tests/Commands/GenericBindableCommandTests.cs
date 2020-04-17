using System;
using DataBind.Bcl.Commands;
using FluentAssertions.Execution;
using Moq;
using Xunit;
namespace DataBind.Bcl.Tests.Commands {

	public class GenericBindableCommandTests {

		[Fact]
		public void GenericBindableCommand_Throws_Error_When_Action_Is_Null() {

			Assert.Throws<ArgumentNullException>(
				() => {

					var command = new BindableCommand<string>(null);

				});

		}

		[Fact]
		public void GenericBindableCommand_Throws_Error_When_Action_Is_Not_Null_And_Predicate_Is_Null() {

			var action = new Mock<Action<string>>();
			action.Setup(x => x(It.IsAny<string>()));

			Assert.Throws<ArgumentNullException>(
				() => {

					var command = new BindableCommand<string>(action.Object, null);

				});

		}

		[Fact]
		public void GenericBindableCommand_Action_Is_Executed_Only_Once() {

			var action = new Mock<Action<string>>();
			action.Setup(x => x(It.IsAny<string>()));

			var command = new BindableCommand<string>(action.Object);
			command.Execute("");

			action.Verify(a => a(""), Times.AtMostOnce());
		}

		[Fact]
		public void GenericBindableCommand_CanExecuteAction_Is_Executed_Only_Once() {

			var action = new Mock<Action<string>>();
			action.Setup(x => x(It.IsAny<string>()));

			var canExecuteAction = new Mock<Func<string,bool>>();
			canExecuteAction.Setup(x => x(It.IsAny<string>())).Returns(false);

			var command = new BindableCommand<string>(action.Object, canExecuteAction.Object);
			var actual = command.CanExecute("");
			var expected = false;

			using (new AssertionScope()) {
				canExecuteAction.Verify(a => a(""), Times.AtMostOnce());
				Assert.Equal(expected, actual);
			}
		}

	}

}