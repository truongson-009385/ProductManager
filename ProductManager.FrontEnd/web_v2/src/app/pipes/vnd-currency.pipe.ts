import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'vndCurrency'
})
export class VndCurrencyPipe implements PipeTransform {
  transform(value: number | string, withSymbol: boolean = true): string {
    if (value === null || value === undefined || value === '') return '';

    const numberValue = typeof value === 'string' ? Number(value) : value;
    if (isNaN(numberValue)) return value.toString();

    const formatted = numberValue.toLocaleString('vi-VN');
    return withSymbol ? `${formatted} VND` : formatted;
  }
}
