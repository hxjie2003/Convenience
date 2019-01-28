-- Add/modify columns 
alter table BM_TRAFFIC_ORDER_DETAIL add ARCHIVE_NO VARCHAR2(50);
-- Add comments to the columns 
comment on column BM_TRAFFIC_ORDER_DETAIL.archive_no is '文书号';

--非空列加默认值
update bm_traffic_order_detail set is_online_processing = 0 where is_online_processing is null 
update bm_traffic_order_detail set deal_times = 0 where deal_times is null;
update bm_traffic_order_detail set is_online_processing = 0 where is_online_processing is null;
update bm_traffic_order_detail set deduct_points = 0 where deduct_points is null;


alter table BM_TRAFFIC_ORDER_DETAIL modify fine_fee default 0 not null;
alter table BM_TRAFFIC_ORDER_DETAIL modify deal_fee default 0 not null;
alter table BM_TRAFFIC_ORDER_DETAIL modify late_fee default 0 not null;
alter table BM_TRAFFIC_ORDER_DETAIL modify mail_fee default 0 not null;
alter table BM_TRAFFIC_ORDER_DETAIL modify t_fee default 0 not null;
alter table BM_TRAFFIC_ORDER_DETAIL modify deduct_points default 0 not null;
alter table BM_TRAFFIC_ORDER_DETAIL modify deal_times default 0 not null;
alter table BM_TRAFFIC_ORDER_DETAIL modify is_online_processing NUMBER(1) default 0;

commit;
