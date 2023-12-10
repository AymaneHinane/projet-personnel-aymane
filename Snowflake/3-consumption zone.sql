use schema PROJECTETLWORKFLOW.CONSUMPTION_ZONE;


create or replace table item_dim(
    item_dim_key number autoincrement,
    item_id varchar(16),
    item_desc varchar,
    start_date date,
    end_date date,
    price number(7,2),
    item_class varchar(50),
    item_category varchar(50),
    added_timestamp timestamp default current_timestamp(),
    updated_timestamp timestamp default current_timestamp(),
    active_flag varchar(1) default 'Y'
) comment ='this is item table with in consumption schema';


create or replace transient table customer_dim(
    customer_dim_key number autoincrement,
    customer_id varchar(18),
    salutation varchar(18),
    first_name varchar(20),
    last_name varchar(30),
    birth_day number,
    birth_month number,
    birth_year number,
    birth_country varchar(20),
    email_address varchar(50)
) comment ='this is customer table with consumption schema';



create or replace table order_fact(
    order_fact_key number autoincrement,    
    order_date date,
    customer_dim_key number,
    item_dim_key number,     
    order_count number,
    order_quantity number,
    sale_price number(20,2),
    disount_amt number(20,2),
    coupon_amt number(20,2),
    net_paid number(20,2),
    net_paid_tax number(20,2),
    net_profit number(20,2)
) comment ='this is order table with in consumption schema';


show tables;


insert into PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ITEM_DIM(
ITEM_ID, ITEM_DESC, START_DATE, END_DATE, PRICE, ITEM_CLASS, ITEM_CATEGORY
)
select  
ITEM_ID, ITEM_DESC, START_DATE, END_DATE, PRICE, ITEM_CLASS, ITEM_CATEGORY
from PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_ITEM;

select * from PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ITEM_DIM;


insert into PROJECTETLWORKFLOW.CONSUMPTION_ZONE.CUSTOMER_DIM(
CUSTOMER_ID, SALUTATION, FIRST_NAME, LAST_NAME, BIRTH_DAY, BIRTH_MONTH, BIRTH_YEAR, BIRTH_COUNTRY, EMAIL_ADDRESS
)
select 
CUSTOMER_ID, SALUTATION, FIRST_NAME, LAST_NAME, BIRTH_DAY, BIRTH_MONTH, BIRTH_YEAR, BIRTH_COUNTRY, EMAIL_ADDRESS
from PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_CUSTOMER;

select * from PROJECTETLWORKFLOW.CONSUMPTION_ZONE.CUSTOMER_DIM


insert into PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ORDER_FACT(
ORDER_DATE, CUSTOMER_DIM_KEY, ITEM_DIM_KEY,ORDER_COUNT, ORDER_QUANTITY, SALE_PRICE, DISOUNT_AMT, COUPON_AMT, NET_PAID, NET_PAID_TAX, NET_PROFIT
)
select 
 co.order_date, 
 cd.customer_dim_key,
 id.item_dim_key,
 count(1) as order_count,
 sum(co.order_quantity),
 sum(co.sale_price),
 sum(co.disount_amt),
 sum(co.coupon_amt),
 sum(co.net_paid),
 sum(co.net_paid_tax),
 sum(co.net_profit)  
from  PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_ORDER co
join  PROJECTETLWORKFLOW.CONSUMPTION_ZONE.CUSTOMER_DIM cd on cd.customer_id = co.customer_id 
join  PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ITEM_DIM id on id.item_id = co.item_id and id.item_desc = co.item_desc and id.end_date is null
group by
  co.order_date,
  cd.customer_dim_key,
  id.item_dim_key 
order by co.order_date;


select * from PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ORDER_FACT;
