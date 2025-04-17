export interface Product {
  id: number;
  code: string;
  name: string;
  description: string;
  image: string;
  price: number;
  stock: number;
  inventoryStatus: InventoryStatus,
  rating: number;
}

export enum InventoryStatus {
  INSTOCK = 1,
  LOWSTOCK = 2,
  OUTOFSTOCK = 3,
}
