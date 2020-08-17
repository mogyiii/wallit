alter table credit_card add column user_id int4;
alter table credit_card add constraint fk_user_credit_card foreign key (user_id) references "user";
create index ix_credit_card_user_id on credit_card (user_id)