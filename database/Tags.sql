use Zeega;
go

if(exists(select table_name
		  from INFORMATION_SCHEMA.TABLES
		  where TABLE_SCHEMA = 'dbo'
		  and	TABLE_NAME = 'Tags')
)
	drop table dbo.Tags;
go

create table dbo.Tags (
	Id int identity(1, 1) 
		constraint PK_Tag_Id primary key
,	Name nvarchar(30) not null
,	Slug nvarchar(60) not null
,	LanguageCode nvarchar(2) not null
,	BaseTagId int
	constraint FK_Tags_BaseTagId
		foreign key (BaseTagId) references dbo.Tags(Id)
			on delete no action
			on update no action
);

alter table dbo.Tags
	add constraint UX_Tags_Slug unique(LanguageCode, Slug);
go

exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains tags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tags'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Name',
								@name=N'MS_Description', @value=N'Represents tag name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tags'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Slug',
								@name=N'MS_Description', @value=N'Represents tag slug' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tags'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'LanguageCode',
								@name=N'MS_Description', @value=N'Language code of tag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tags'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'BaseTagId',
								@name=N'MS_Description', @value=N'Base tag id from which this tag was created' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tags'
go