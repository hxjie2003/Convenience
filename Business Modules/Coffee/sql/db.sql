-- Add/modify columns 
alter table BM_COFFEE_DETAIL add materials VARCHAR2(1000);
alter table BM_COFFEE_DETAIL add issued NUMBER(10);

comment on column BM_COFFEE_DETAIL.materials  is '�������Լ�';
comment on column BM_COFFEE_DETAIL.issued  is '�ѳ�����';
