

select * from ARTICULOS
select * from IMAGENES
select * from CATEGORIAS

update IMAGENES SET ImagenUrl= 'https://gmedia.playstation.com/is/image/SIEPDC/ps4-product-thumbnail-01-en-14sep21?$facebook$' where IdArticulo=3
update IMAGENES SET ImagenUrl= 'https://www.sony.com.ar/image/6cba5e659baacc3e99433b4d7f28de6c?fmt=pjpeg&wid=330&bgcolor=FFFFFF&bgc=FFFFFF' where IdArticulo=4
update IMAGENES SET ImagenUrl= 'https://i.blogs.es/9da288/moto-g7-/1366_2000.jpg' where IdArticulo=2

INSERT into IMAGENES(IdArticulo,ImagenUrl) VALUES
(2,'https://ar.celulares.com/fotos/motorola-moto-g7-play-80207-m.jpg'),
(4,'https://intercompras.com/images/product/SONY_KDL-55EX720.jpg'),
(14,'https://http2.mlstatic.com/D_NQ_NP_626328-MLA44456373038_122020-O.webp'),
(15,'https://support.apple.com/library/APPLE/APPLECARE_ALLGEOS/SP845/apple-tv-4k-2gen-ports-mx.png')
go
--SP para Articulos
ALTER procedure storedListarURL as 
select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion as Marca, C.Descripcion as Categoria, (select  top 1(ImagenUrl)
from IMAGENES I
WHERE I.IdArticulo=A.Id) as ImagenUrl 
from ARTICULOS A
inner join MARCAS M on M.Id = A.IdMarca
inner join CATEGORIAS C on C.Id = A.IdCategoria

GO
exec storedListarURL
go

ALTER PROCEDURE SPArticuloImg(
    @id int
)
AS
BEGIN
    -- Obtener el primer artículo de la tabla
    DECLARE @Articulo TABLE (
        Id int,
        Codigo varchar(50),
        Nombre varchar(100),
        Descripcion varchar(200),
        Precio decimal(18, 2),
        Marca varchar(100),
        Categoria varchar(100)
    )

    INSERT INTO @Articulo (Id, Codigo, Nombre, Descripcion, Precio, Marca, Categoria)
    EXEC SPArticulosID @id
        

    -- Obtener la imagen del artículo
    DECLARE @ImagenUrl varchar(200)

    SELECT TOP 1 @ImagenUrl = ImagenUrl
    FROM IMAGENES
    WHERE IdArticulo = @id

    -- Devolver los datos del artículo con la imagen
    SELECT
        Id,
        Codigo,
        Nombre,
        Descripcion,
        Precio,
        Marca,
        Categoria,
        @ImagenUrl AS ImagenUrl
    FROM @Articulo
END
go

GO

create procedure SPArticulosID (
    @id int
)
as 
select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion as Marca, C.Descripcion as Categoria
from ARTICULOS A
inner join MARCAS M on M.Id = A.IdMarca
inner join CATEGORIAS C on C.Id = A.IdCategoria
WHERE @id=A.Id
GO

create procedure SPImagenes(
     @id int
)
as 
select Id,IdArticulo,ImagenUrl
from IMAGENES I
WHERE IdArticulo=@id
go

create procedure SPImagenesTop
as 
select  IdArticulo, Id, ImagenUrl
from IMAGENES I
go



