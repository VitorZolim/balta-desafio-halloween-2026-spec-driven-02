using ShortLink.Core;

namespace ShortLink.Tests;

public class LinkCodeGeneratorTests
{
    [Fact]
    public void Generate_ShouldReturnSevenCharactersFromTheUnambiguousAlphabet()
    {
        for (var i = 0; i < 250; i++)
        {
            var code = LinkCodeGenerator.Generate();

            Assert.Equal(LinkCodeGenerator.Length, code.Length);
            Assert.True(
                code.All(character => "ABCDEFGHJKLMNPQRSTUVWXYZ23456789".Contains(character)),
                $"O código '{code}' contém caracteres fora do alfabeto permitido.");
            Assert.True(LinkCodeGenerator.IsValid(code));
        }
    }
}
