using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace blockchainGob.Localization
{
    public static class blockchainGobLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(blockchainGobConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(blockchainGobLocalizationConfigurer).GetAssembly(),
                        "blockchainGob.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
