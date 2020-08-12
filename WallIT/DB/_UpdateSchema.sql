alter table record_category add column subject_id int4;
create table record_planned (id  serial, name varchar(255), amount float8, currency varchar(255), deadline_utc timestamp, is_repeat boolean, is_paid boolean, creation_date_utc timestamp, modification_date_utc timestamp, record_category_id int4, primary key (id));
create table subject (id  serial, name varchar(255), balance float8, subject_type varchar(255), currency varchar(255), creation_date_utc timestamp, modification_date_utc timestamp, user_id int4, credit_card_id int4, primary key (id));
alter table record_category add constraint fk_subject_record_category foreign key (subject_id) references subject;
create index ix_record_category_subject_id on record_category (subject_id);
alter table record_planned add constraint fk_record_category_record_planned foreign key (record_category_id) references record_category;
create index ix_record_planned_record_category_id on record_planned (record_category_id);
alter table subject add constraint fk_user_subject foreign key (user_id) references "user";
alter table subject add constraint fk_credit_card_subject foreign key (credit_card_id) references credit_card;
create index ix_subject_user_id on subject (user_id);
create index ix_subject_credit_card_id on subject (credit_card_id)