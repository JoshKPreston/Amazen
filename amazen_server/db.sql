
create table profiles(
  profile_id varchar(255) not null primary key,
  profile_name varchar(255) not null,
  profile_email varchar(255) not null,
  profile_picture varchar(255) not null
)

create table products(
  product_id int not null auto_increment primary key,
  product_image varchar(255) not null,
  product_category varchar(255) not null unique,
  product_title varchar(255) not null,
  product_description varchar(1020) not null,
  product_price decimal(8,2) not null,
  product_rating decimal(3,2) not null,
  product_creator_id varchar(255),
  foreign key(product_creator_id)
    references profiles(profile_id)
    on delete cascade,
  index idx_product_category (product_category),
  index idx_product_title (product_title),
  index idx_product_rating (product_rating),
  index idx_product_creator_id (product_creator_id)
)

create table product_reviews(
  product_review_id int not null auto_increment primary key,
  product_review_rating tinyint(1) not null,
  product_review_text varchar(1020) not null,
  product_review_product_id int,
  product_review_creator_id varchar(255),
  foreign key(product_review_product_id)
    references products(product_id)
    on delete cascade,
  foreign key(product_review_creator_id)
    references profiles(profile_id),
  index idx_product_review_product_id (product_review_product_id),
  index idx_product_review_creator_id (product_review_creator_id)
)

create table user_wishlists(
  user_wishlist_id int not null auto_increment primary key,
  user_wishlist_title varchar(255) not null,
  user_wishlist_product_id int,
  user_wishlist_creator_id varchar(255),
  foreign key(user_wishlist_product_id)
    references products(product_id),
  foreign key(user_wishlist_creator_id)
    references profiles(profile_id)
    on delete cascade,
  index idx_user_wishlist_title (user_wishlist_title),
  index idx_user_wishlist_product_id (user_wishlist_product_id),
  index idx_user_wishlist_creator_id (user_wishlist_creator_id)
)

