using Bogus;

namespace ConsoleApp2
{
	public class Mock
	{
		public Dummy GetData()
		{
			var data = new Faker<Dummy>()
				.RuleFor(i => i.Message, f => f.Lorem.Paragraph())
				.RuleFor(i => i.Name, f => f.Name.FullName())
				.RuleFor(i => i.Id, f => f.Random.Guid().ToString());

			return data.Generate();
		}
	}
}
