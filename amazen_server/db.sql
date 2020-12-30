
create table profiles(
  id varchar(255) not null primary key,
  name varchar(255) not null,
  email varchar(255) not null,
  picture varchar(255) not null
)

create table products(
  id int not null auto_increment primary key,
  image varchar(255) not null,
  category varchar(255) not null,
  title varchar(255) not null,
  description varchar(1020) not null,
  price decimal(8,2) not null,
  rating decimal(3,2) not null,
  creatorId varchar(255),
  foreign key(creatorId)
    references profiles(id)
    on delete cascade,
  index idxCategory (category),
  index idxTitle (title),
  index idxRating (rating),
  index idxCreatorId (creatorId)
)

create table reviews(
  id int not null auto_increment primary key,
  rating tinyint(1) not null,
  text varchar(1020) not null,
  productId int,
  creatorId varchar(255),
  foreign key(productId)
    references products(id)
    on delete cascade,
  foreign key(creatorId)
    references profiles(id),
  index idxId (id),
  index idxCreatorId (creatorId)
)

create table userWishlists(
  id int not null auto_increment primary key,
  title varchar(255) not null,
  creatorId varchar(255),
  foreign key(creatorId)
    references profiles(id)
    on delete cascade,
  index idxTitle (title),
  index idxCreatorId (creatorId)
)

create table wishlistItems(
  id int not null auto_increment primary key,
  wishlistId int,
  productId int,
  foreign key(wishlistId)
    references userWishlists(id)
    on delete cascade,
  foreign key(productId)
    references products(id),
  index idxWishlistId (wishlistId),
  index idxId (id)
)

