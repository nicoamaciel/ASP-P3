

select * from ARTICULOS
select * from IMAGENES
select * from CATEGORIAS

update IMAGENES SET ImagenUrl= 'https://gmedia.playstation.com/is/image/SIEPDC/ps4-product-thumbnail-01-en-14sep21?$facebook$' where IdArticulo=3
update IMAGENES SET ImagenUrl= 'https://www.sony.com.ar/image/6cba5e659baacc3e99433b4d7f28de6c?fmt=pjpeg&wid=330&bgcolor=FFFFFF&bgc=FFFFFF' where IdArticulo=4
update IMAGENES SET ImagenUrl= 'https://i.blogs.es/9da288/moto-g7-/1366_2000.jpg' where IdArticulo=2



create procedure storedListarURL as 
select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Descripcion as Marca, C.Descripcion as Categoria, I.ImagenUrl as ImagenUrl 
from ARTICULOS A
inner join MARCAS M on M.Id = A.IdMarca
inner join CATEGORIAS C on C.Id = A.IdCategoria
inner join IMAGENES I on I.IdArticulo = A.Id


exec storedListarURL

delete from ARTICULOS where Id=3
