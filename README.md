# Sustainable.Web.Sniply
TagHelper and Utility classes to utilize Sniply for outgoing links

The package works by setting up a Razor page that will redirect to Sniply when it is called with the parameter url. Why that can be a good thing check out https://snip.ly but the basic premise is:

* You get statistics about outgoing page clicks
* (supported) Outgoing pages are still branded by you

## Configuration

### settings.json / Azure WebApp Settings

Put the following in Startup.cs
```c#
services.Configure<Sniply.SniplyOptions>(Configuration.GetSection("sniply"));
```

```json
{
  ...,
  "sniply": {
    "SiteId": "<siteid>",
  },
  ...,
  "AllowedHosts": "*"
}
```
### Direct configuration
```c#
services.Configure<Sniply.SniplyOptions>(options =>
{
    options.SiteId = "<siteid>";
});
```

## Customize the url on the server
It is quite easy to change the path of the Sniply forwarding page. By default it is /sniply/?url=, it can be changed by using Razor Pages Options

```c#
services.AddMvc().AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddAreaPageRoute("Sniply", "/Index", "ReadThis/{url}");
                });
```


## Where to find the SiteId

The siteid can be found in your sniply dashboard. 

1. Go to Integrations
2. Then to "Embed on Website"
3. Under "Add a site" type your domain name (or any domain name, it is not important unless you are using the other features) and click "Continue"
4. In the popup extract the site id from the url of the javascript.

```js
<script type="text/javascript" src="https://gosniply.com/site/[THISISTHESITEID].js"></script>
```

