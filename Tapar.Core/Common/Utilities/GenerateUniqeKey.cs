
using shortid;
using shortid.Configuration;

namespace Tapar.Core.Common.Utilities;

public class GenerateUniqeKey
{
    public static string GenerateUniqueKey()
    {
        //https://github.com/bolorundurowb/shortid
        var options = new GenerationOptions(length: 8, useSpecialCharacters: false,useNumbers:true);
        string id = ShortId.Generate(options);
        return id;
    }
}