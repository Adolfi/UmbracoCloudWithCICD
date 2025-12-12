using UmbracoProject.Extensions;

namespace UmbracoProject.Tests.UnitTests;

[TestFixture]
public class StringExtensionsTests
{
    [Test]
    public void ReplaceSpecialCharacters_WithWindowsLineBreak_ReplacesWithSpace()
    {
        // Arrange
        var input = "Hello\r\nWorld";
        
        // Act
        var result = input.ReplaceSpecialCharacters();
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void ReplaceSpecialCharacters_WithUnixLineBreak_ReplacesWithSpace()
    {
        // Arrange
        var input = "Hello\nWorld";
        
        // Act
        var result = input.ReplaceSpecialCharacters();
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void ReplaceSpecialCharacters_WithMacLineBreak_ReplacesWithSpace()
    {
        // Arrange
        var input = "Hello\rWorld";
        
        // Act
        var result = input.ReplaceSpecialCharacters();
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void ReplaceSpecialCharacters_WithTab_ReplacesWithSpace()
    {
        // Arrange
        var input = "Hello\tWorld";
        
        // Act
        var result = input.ReplaceSpecialCharacters();
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void ReplaceSpecialCharacters_WithMultipleSpecialCharacters_ReplacesAll()
    {
        // Arrange
        var input = "Hello\r\nWorld\tTest\fValue\vEnd";
        
        // Act
        var result = input.ReplaceSpecialCharacters();
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello World Test Value End"));
    }

    [Test]
    public void ReplaceSpecialCharacters_WithCustomReplacement_UsesCustomString()
    {
        // Arrange
        var input = "Hello\nWorld";
        
        // Act
        var result = input.ReplaceSpecialCharacters("-");
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello-World"));
    }

    [Test]
    public void ReplaceSpecialCharacters_WithNullInput_ReturnsNull()
    {
        // Arrange
        string? input = null;
        
        // Act
        var result = input.ReplaceSpecialCharacters();
        
        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void ReplaceSpecialCharacters_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = "";
        
        // Act
        var result = input.ReplaceSpecialCharacters();
        
        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void ReplaceSpecialCharactersAndNormalize_WithMultipleSpaces_NormalizesToSingleSpace()
    {
        // Arrange
        var input = "Hello\r\n\r\nWorld\t\tTest";
        
        // Act
        var result = input.ReplaceSpecialCharactersAndNormalize();
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello World Test"));
    }

    [Test]
    public void ReplaceSpecialCharactersAndNormalize_WithLeadingAndTrailingSpaces_TrimsSpaces()
    {
        // Arrange
        var input = "  Hello\nWorld  ";
        
        // Act
        var result = input.ReplaceSpecialCharactersAndNormalize();
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void ReplaceSpecialCharactersAndNormalize_WithNullInput_ReturnsNull()
    {
        // Arrange
        string? input = null;
        
        // Act
        var result = input.ReplaceSpecialCharactersAndNormalize();
        
        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void ReplaceSpecialCharactersAndNormalize_WithComplexString_HandlesCorrectly()
    {
        // Arrange
        var input = "  First\r\n\r\nSecond\t\t\tThird   Fourth  ";
        
        // Act
        var result = input.ReplaceSpecialCharactersAndNormalize();
        
        // Assert
        Assert.That(result, Is.EqualTo("First Second Third Fourth"));
    }
}
