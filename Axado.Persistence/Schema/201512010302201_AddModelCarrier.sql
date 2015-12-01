﻿use axado
go


CREATE TABLE [dbo].[Carriers] (
    [id] [int] NOT NULL IDENTITY,
    [active] [bit] NOT NULL DEFAULT 1,
    [created_at] [datetime2](3) NOT NULL DEFAULT sysutcdatetime(),
    [updated_at] [datetime2](3),
    [deleted_at] [datetime2](3),
    [name] [varchar](100) NOT NULL,
    [code] [varchar](50) NOT NULL,
    [identification] [varchar](40) NOT NULL,
    [streetaddress] [varchar](100) NOT NULL,
    [district] [varchar](100) NOT NULL,
    [locality] [varchar](100) NOT NULL,
    [region] [varchar](3) NOT NULL,
    [country] [varchar](2) NOT NULL,
    [phone_number] [varchar](20) NOT NULL,
    [url] [varchar](256),
    [price_per_km] [decimal](7, 3) NOT NULL,
    CONSTRAINT [pk_Carriers] PRIMARY KEY ([id])
);
go

CREATE UNIQUE INDEX [ak_Carriers] ON [dbo].[Carriers]([code]);
go

INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201512010302201_AddModelCarrier', N'Axado.Persistence.Migrations.Configuration',  0x1F8B0800000000000400CD59DB6EDB38107D5F60FF41D0736AE5D2EE25905BA44EB3089A1BE2A4AF012D8D1D2214A592546063B15FB60FFB49FB0B3BD495A224DB4A1D6451A08886E499E170386786FEF7EF7FFC4FCB8839CF20248DF9D83D18EDBB0EF0200E295F8CDD54CDDFFDE67EFAF8F34FFE97305A3ADFCA79477A1EAEE472EC3E2A951C7B9E0C1E21227214D140C4329EAB5110471E0963EF707FFF77EFE0C003847011CB71FCDB942B1A41F6819F93980790A894B0CB3804260B398E4C3354E78A44201312C0D83D5922E6E8465B22159A0AAE73C2284143A6C0E6AE43388F155168E6F1BD84A912315F4C13141076B74A00E7CD099350987F5C4FDF7627FB877A275EBDB0840A52A9E26820E0C151E11ACF5EFE2207BB95EB32B7460983A5DE76E641745E180A90D2756C65C71326F4BCD2BFA74491517E18A362D19E530FED55A18011A3FFED399394A954C09843AA04617BCE4D3A6334F80AABBBF809F898A78C99D6A17D37224E40A855611C9E1580AA4CCCCD412186A2EB5C92E505F0857AC420DDC7E03BA34B084B4971A2F79C62E442F57D852AC98CD5026FADFE530C284103F506AA2FE28030AA566FA0FA161659B0F52A3E7A15B59318538058B7E1C31DE8F53DE30E98F22F987FD4CAB8191322040531EC66148B767F3370AC2130FC770BF3C2E4F3B0E564CF5E68BB5DAFC97773CED5D16187FB8C9D4F552CE00FE0208882F0862805826B0CC8BCB7E988F5FF6F10D0135CBB46ED87D7D19A3B654E832277F7EA7FFF3AFAEDB4895C38AA6403B16E1E630E576934D3F7A1FF7EBECE46EE055BA7F4C32FDB69DDB043CCF38035C4D7A8D4750A018D08AABE11F8575EE5FCEA3A53CCCB90E5C0A1E71128FA5CC5E1E7386640F8F05816A0AFDE49C5499862E08EEA7B65D839DCBAFB24DC0E7703630283C130BE5727DF764AC65250118A29A7F4A3CEAC5A084BD5919CB1C42BF233164A4AA46025D21C740AAA99E6F14ED44614B7A562802E632BB3EAD2D4CB6BD3B286F57A8A58FF92240986B151D41612679A57B49377D3E1B55E9463788174D738B1D284999C2CC01ACD73E519155269EA9A111D3893306A4D6B1C428F834B55969F6D1AABDD5E2ED07F1B676D96F6D5995828B50FCF705B1166DE6C87501953F3796B65D65410464407334E6296463CFFA62D765DB73AE73A733DCF24DB23E4B465220499647B049B829ABB698E75A216B5D23A66E93BA87252076C9FB956B96F5A2BB321520E7519DB875A17F1266058498760D555B989C52AE910ACB2CC369144211B8253D5CDCD4829849DC7EA59E7BA754035EA00535FA2071E7831B27D8466DC6E02A55AB0FD7A93B61BF668F903CE7C788A86E095246D62914236E0E6D624DD38945CFC407AA2AEC7453533371C958B078219FCDCB80DB9B807CCF7ACDC6AA770AF95C3AD26C4E684757C6A4FA9B457BC6AF1A75F70D9E697A216B9E553746D123F634244629BAE307F45794F37FDCE268CE27EEB099784D3394895F76958F11E1C5AAF4DFF9F971F4FCA9075D4021D3DEE0B7ACD361B6EEE3569D56B52EDD48DDDE4C01A961BEDE53311C12311EDFE72206660F48E1566ABE83CE7212CC7EE9FD9A263873C3D94E5CE9E732EB113F99EA2F80EAB51E7AF56EF39D0229BB8FBF7FB7E38B8C5B3BBF565683DA7ED0A97596F65BBC2158D87B02ED4E17D56D07CE5EA02ED7A83590FDA64DF35C8C37D90D6CD7727A2EEBE6BC8ACDFDA646C839A73E870C7BD3669F4DA33AA869F93C1D5858DF8AD7FA238FCC14EDB24EEAD91B771AC49E23F003CAC1B6FF78B5BB5DBEBBAED9C94D1FA598C1BC9CDACBBF417F6E2ED1AC1F7CCDF9CFC5390745143E85FA038043AC5D6A0E59C733E8F4BE7E3D64C8BCA29D6D95CEAA48A1E3A1198BA313A7138C00C9B3D667D232CC5295FF0F686E7FC3A5549AA4EA48468C61A05BCEFADD79F3D38346DF6AF13FD2577B1053493EA80BAE69F53CAC2CAEEB38E47F61E081D2C05DFA355D8EE21DC6255215D6116DB0EA870DF2924C0351DDE01F6330826AFF994E88B3FDCB67B0917B020C1AA2CF5FA41361F44D3EDFE29250B41225960D4EBF5EFA89EFE21F5E37FE89C3E337A1D0000 , N'6.1.3-40302');
go