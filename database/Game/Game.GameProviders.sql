use Zeega;
go

if(exists(select table_name
		  from INFORMATION_SCHEMA.TABLES
		  where TABLE_SCHEMA = 'Game'
		  and	TABLE_NAME = 'GameProviders')
)
	drop table Game.GameProviders;
go

create table Game.GameProviders (
	Id int identity(1, 1) 
		constraint PK_GameProv_Id primary key
,	Name nvarchar(30) not null
,	OfficialUrl nvarchar(255) not null
,	PublisherUrl nvarchar(255)
,	HasPublisherApi bit not null default 0
,	GamesCatalogUrl nvarchar(255)
,	HasXmlFeed bit not null default 0
,	HasJsonFeed bit not null default 0
,	IsActive bit not null default 1
);



exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains game providers',
								@level1type=N'TABLE',@level1name=N'GameProviders',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Name',
								@name=N'MS_Description', @value=N'Game provider name',
								@level1type=N'TABLE', @level1name=N'GameProviders',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'OfficialUrl',
								@name=N'MS_Description', @value=N'Game provider official url',
								@level1type=N'TABLE',@level1name=N'GameProviders',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'PublisherUrl',
								@name=N'MS_Description', @value=N'Game provider publisher url',
								@level1type=N'TABLE',@level1name=N'GameProviders',
								@level0type=N'SCHEMA', @level0name=N'Game'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GamesCatalogUrl',
								@name=N'MS_Description', @value=N'Game provider catalog url',
								@level1type=N'TABLE',@level1name=N'GameProviders',
								@level0type=N'SCHEMA', @level0name=N'Game'

exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'HasPublisherApi',
								@name=N'MS_Description', @value=N'Column indicates if game provider has a publisher api',
								@level1type=N'TABLE',@level1name=N'GameProviders',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'HasXmlFeed',
								@name=N'MS_Description', @value=N'Column indicates if game provider has xml game feed',
								@level1type=N'TABLE',@level1name=N'GameProviders',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'HasJsonFeed',
								@name=N'MS_Description', @value=N'Column indicates if game provider has json game feed',
								@level1type=N'TABLE',@level1name=N'GameProviders',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'IsActive',
								@name=N'MS_Description', @value=N'Is game provider active',
								@level1type=N'TABLE',@level1name=N'GameProviders',
								@level0type=N'SCHEMA', @level0name=N'Game'
go