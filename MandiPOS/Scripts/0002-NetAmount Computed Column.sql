ALTER TABLE tblSale
ADD Remaining AS (SaleAmount2 - CommissionAmount - MazdooriAmount - MunshianaAmount - KarayaAmount - StoreRent-PaidAmount) PERSISTED;