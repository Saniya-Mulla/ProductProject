import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Products } from '../products';
import { ProductsServiceService } from '../products-service.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {
  @Input() prod?: Products;
  @Output() prodsUpdated = new EventEmitter<Products[]>();

  constructor(private prodservice: ProductsServiceService) {}

  ngOnInit(): void {}

  updateProducts(prod: Products) {
    this.prodservice
      .updateProduct(prod)
      .subscribe((prods: Products[]) => this.prodsUpdated.emit(prods));
  }

  deleteProduct(prod: Products) {
    this.prodservice
      .deleteProduct(prod)
      .subscribe((prods: Products[]) => this.prodsUpdated.emit(prods));
  }

  AddProd(prod: Products) {
    this.prodservice
      .addProd(prod)
      .subscribe((prods: Products[]) => this.prodsUpdated.emit(prods));;
  }
}
