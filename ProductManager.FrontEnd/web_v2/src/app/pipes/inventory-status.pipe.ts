import { Pipe, PipeTransform } from '@angular/core';
import { InventoryStatus } from '../models';

@Pipe({
  name: 'inventoryStatus'
})
export class InventoryStatusPipe implements PipeTransform {
  transform(value: InventoryStatus | number): string {
    switch (value) {
      case InventoryStatus.INSTOCK:
        return 'In stock';
      case InventoryStatus.LOWSTOCK:
        return 'Low stock';
      case InventoryStatus.OUTOFSTOCK:
        return 'Out of stock';
      default:
        return 'Unknown status';
    }
  }
}
