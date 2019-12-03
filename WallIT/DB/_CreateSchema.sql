create table credit_card (id  serial, name varchar(255) not null, creation_date_utc timestamp, modification_date_utc timestamp, primary key (id));
create table record (id  serial, amount float8, currency varchar(255), transaction_date_utc timestamp, creation_date_utc timestamp, modification_date_utc timestamp, primary key (id));
create table user_claim (id  serial, claim_type varchar(255), claim_value varchar(255), creation_date_utc timestamp, modification_date_utc timestamp, user_id int4, primary key (id));
create table "user" (id  serial, name varchar(255), user_name varchar(255), normalized_user_name varchar(255), password_hash varchar(255), email varchar(255), last_attempt_utc timestamp, access_failed_count int4, last_logged_in_utc timestamp, is_last_login_persistent boolean, security_stamp varchar(255), lockout_enabled boolean, lockout_end timestamp, creation_date_utc timestamp, modification_date_utc timestamp, primary key (id));
create index ix_user_claim_user_id on user_claim (user_id);
alter table user_claim add constraint fk_user_user_claim foreign key (user_id) references "user"