using NUnit.Framework;

namespace Sobriquet.Tests
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void Test()
		{
			var defaultGenerator = new DefaultGenerators(3);

			var maleName = defaultGenerator.MaleFirstName.Next();
			var femaleName = defaultGenerator.FemaleFirstName.Next();
			var lastName = defaultGenerator.LastName.Next();
		}

	}
}