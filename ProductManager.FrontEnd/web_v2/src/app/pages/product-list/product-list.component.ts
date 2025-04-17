import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { RatingModule } from 'primeng/rating';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { InventoryStatus, Product } from '../../models';
import { ProductService } from '../../services/product.service';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../environments/environment';
import { InventoryStatusPipe } from '../../pipes/inventory-status.pipe';
import { VndCurrencyPipe } from '../../pipes/vnd-currency.pipe';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css',
  imports: [
    TableModule,
    TagModule,
    RatingModule,
    ButtonModule,
    CommonModule,
    FormsModule,
    InventoryStatusPipe,
    VndCurrencyPipe,
    RouterLink
  ],
})
export class ProductListComponent {
  products!: Product[];
  $url = environment.apiUrl;

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.productService.getAllProducts().subscribe((data) => {
      this.products = data;

      console.log(data);
    });
  }

  getSeverity(
    status: InventoryStatus
  ):
    | 'success'
    | 'secondary'
    | 'info'
    | 'warn'
    | 'danger'
    | 'contrast'
    | undefined {
    switch (status) {
      case 1:
        return 'success';
      case 2:
        return 'warn';
      case 3:
        return 'danger';
      default:
        return 'secondary';
    }
  }
}
