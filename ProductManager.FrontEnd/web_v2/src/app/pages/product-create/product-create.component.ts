import { Component } from '@angular/core';
import { InventoryStatus, UploadEvent } from '../../models';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { RatingModule } from 'primeng/rating';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabelModule } from 'primeng/floatlabel';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { TextareaModule } from 'primeng/textarea';
import { InputNumberModule } from 'primeng/inputnumber';
import { FileUpload } from 'primeng/fileupload';
import { Select } from 'primeng/select';

@Component({
  selector: 'app-product-create',
  imports: [
    DropdownModule,
    RatingModule,
    ReactiveFormsModule,
    InputTextModule,
    FloatLabelModule,
    TextareaModule,
    ButtonModule,
    InputNumberModule,
    FileUpload,
    DropdownModule,
    Select,
    CommonModule,
  ],
  templateUrl: './product-create.component.html',
  styleUrl: './product-create.component.css'
})
export class ProductCreateComponent {
  productForm!: FormGroup;
  uploadedFiles: any[] = [];
  statuses = [
    { name: 'In Stock', value: 'INSTOCK' },
    { name: 'Low Stock', value: 'LOWSTOCK' },
    { name: 'Out of Stock', value: 'OUTOFSTOCK' },
  ];

  inventoryStatusOptions = [
    { label: 'In Stock', value: InventoryStatus.INSTOCK },
    { label: 'Low Stock', value: InventoryStatus.LOWSTOCK },
    { label: 'Out of Stock', value: InventoryStatus.OUTOFSTOCK },
  ];

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.productForm = this.fb.group({
      id: [null],
      code: ['', Validators.required],
      name: ['', Validators.required],
      description: [''],
      image: [''],
      price: [0, [Validators.required, Validators.min(0)]],
      stock: [0, [Validators.required, Validators.min(0)]],
      inventoryStatus: [InventoryStatus.INSTOCK],
      rating: [0, [Validators.min(0), Validators.max(5)]],
    });
  }

  onSubmit() {
    if (this.productForm.valid) {
      console.log('Submitted product:', this.productForm.value);
    }
  }

  onUpload(event:UploadEvent) {
    for(let file of event.files) {
        this.uploadedFiles.push(file);
    }
  }
}
