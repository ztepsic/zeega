use Zeega;
go

if(exists(select table_name
		  from INFORMATION_SCHEMA.TABLES
		  where TABLE_SCHEMA = 'Game'
		  and	TABLE_NAME = 'GameCategories')
)
	drop table Game.GameCategories;
go

create table Game.GameCategories (
	Id int identity(1, 1) 
		constraint PK_GameCat_Id primary key
,	Name nvarchar(30) not null
,	Slug nvarchar(60) not null
);

alter table Game.GameCategories
	add constraint UX_GameCat_Slug unique(Slug);
go



exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains game categories',
								@level1type=N'TABLE', @level1name=N'GameCategories',
								@level0type=N'SCHEMA',@level0name=N'Game'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Name',
								@name=N'MS_Description', @value=N'Game category name',
								@level1type=N'TABLE', @level1name=N'GameCategories',
								@level0type=N'SCHEMA',@level0name=N'Game'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Game category slug value',
								@level2type=N'COLUMN', @level2name=N'Slug',
								@level1type=N'TABLE', @level1name=N'GameCategories',
								@level0type=N'SCHEMA', @level0name=N'Game'
go