using Microsoft.AspNetCore.Razor.TagHelpers;

internal class AssetTags : TagHelperComponent
{
    private readonly string tags =
        @"
<style>

@font-face {
  font-family: 'Segoe UI Local';
  src: local('Segoe UI Light');
  font-weight: 100;
  font-style: normal;
}

@font-face {
  font-family: 'Segoe UI Local';
  src: local('Segoe UI Semilight');
  font-weight: 300;
  font-style: normal;
}

@font-face {
  font-family: 'Segoe UI Local';
  src: local('Segoe UI');
  font-weight: 400;
  font-style: normal;
}

@font-face {
  font-family: 'Segoe UI Local';
  src: local('Segoe UI Semibold');
  font-weight: 600;
  font-style: normal;
}

@font-face {
  font-family: 'Segoe UI Web (West European)';
  src: url('https://static2.sharepointonline.com/files/fabric/assets/fonts/segoeui-westeuropean/segoeui-light.woff2') format('woff2'), url('https://static2.sharepointonline.com/files/fabric/assets/fonts/segoeui-westeuropean/segoeui-light.woff') format('woff');
  font-weight: 100;
  font-style: normal;
}

@font-face {
  font-family: 'Segoe UI Web (West European)';
  src: url('https://static2.sharepointonline.com/files/fabric/assets/fonts/segoeui-westeuropean/segoeui-semilight.woff2') format('woff2'), url('https://static2.sharepointonline.com/files/fabric/assets/fonts/segoeui-westeuropean/segoeui-semilight.woff') format('woff');
  font-weight: 300;
  font-style: normal;
}

@font-face {
  font-family: 'Segoe UI Web (West European)';
  src: url('https://static2.sharepointonline.com/files/fabric/assets/fonts/segoeui-westeuropean/segoeui-regular.woff2') format('woff2'), url('https://static2.sharepointonline.com/files/fabric/assets/fonts/segoeui-westeuropean/segoeui-regular.woff') format('woff');
  font-weight: 400;
  font-style: normal;
}

@font-face {
  font-family: 'Segoe UI Web (West European)';
  src: url('https://static2.sharepointonline.com/files/fabric/assets/fonts/segoeui-westeuropean/segoeui-semibold.woff2') format('woff2'), url('https://static2.sharepointonline.com/files/fabric/assets/fonts/segoeui-westeuropean/segoeui-semibold.woff') format('woff');
  font-weight: 600;
  font-style: normal;
}
</style>";

    public override int Order => 1;

    public override Task ProcessAsync(TagHelperContext context,
                                      TagHelperOutput output)
    {
        if(string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
        {
            output.PostContent.AppendHtml(tags);
        }

        return Task.CompletedTask;
    }
}
