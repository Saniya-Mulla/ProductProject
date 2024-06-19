import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Products } from './products';

@Injectable({
  providedIn: 'root'
})
export class ProductsServiceService {

  constructor(private httpClient: HttpClient) { 

  }
  public getAllProducts():Observable<Products[]>
  {
    return this.httpClient.get<Products[]>("http://localhost:5157/api/Products");
  }

  public updateProduct(existingProduct: Products): Observable<Products[]> {
    return this.httpClient.put<Products[]>("http://localhost:5157/api/Products",existingProduct
    );
  }

  public deleteProduct(prod: Products): Observable<Products[]> {
    return this.httpClient.delete<Products[]>(
      "http://localhost:5157/api/Products/"+prod.productId
    );
  }

  public addProd(prod: Products): Observable<Products[]> {
    return this.httpClient.post<Products[]>(
      "http://localhost:5157/api/Products",
      prod
    );
  }

}
