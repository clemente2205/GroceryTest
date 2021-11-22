create table tblProducts(
idProduct int primary key identity(1,1),
title varchar(255),
price money,
description varchar(MAX),
category varchar(255),
image varchar(MAX),
)