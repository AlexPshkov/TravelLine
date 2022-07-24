import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class SelectionService {
  public readonly domainUrl: string = "http://localhost:4200/api";

  constructor(private http: HttpClient) { }

  /**
   * Gets model(s) from backend
   * @param modelType
   * @param modelUUID
   */
  public getFromBackend( modelType: string, modelUUID: number | null ) {
    const uuidParam = modelUUID != null ? "/" + modelUUID : "";
    return this.http.get(`${this.domainUrl}/${modelType}${uuidParam}`);
  }
}
