import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {SelectionService} from "../../services/selection.service";
import {City} from "../../shared/city.model";
import {House} from "../../shared/house.model";
import {Flat} from "../../shared/flat.model";
import {Citizen} from "../../shared/citizen.model";

@Component({
  selector: 'global-search',
  templateUrl: './global-search.component.html',
  styleUrls: ['./global-search.component.scss']
})
export class GlobalSearchComponent implements OnInit {
  citiesList: Array<City> = [];
  housesList: Array<House> = [];
  flatList: Array<Flat> = [];
  citizenList: Array<Citizen> = [];


  constructor(public selectionService: SelectionService ) { }

  ngOnInit(): void {}


  /**
   * Gets values and prints on the screen
   */
  public makeSearch() {
    this.clearAll();
    if (this.control.value == undefined) return;
    const modelType = this.control.value?.toLowerCase();

    this.selectionService.getFromBackend(modelType, null).subscribe(result => {
      switch (modelType) {
        case "city": {
          this.citiesList = (<Array<Array<City>>>result)[0];
          break;
        }
        case "house": {
          this.housesList = (<Array<House>>result);
          break;
        }
        case "flat": {
          this.flatList = (<Array<Flat>>result);
          break;
        }
        case "citizen": {
          this.citizenList = (<Array<Citizen>>result);
          break;
        }

      }
    });
  }

  /**
   * Clears all lists
   */
  public clearAll() {
    this.citiesList = [];
    this.housesList = [];
    this.flatList = [];
    this.citizenList = [];
  }

  /**
   * Gets empty or not
   */
  public isEmpty(): boolean {
    let a = this.citizenList.length == 0;
    let b = this.citiesList.length == 0;
    let c = this.housesList.length == 0;
    let d = this.flatList.length == 0;
    return (a && b && c && d);
  }

  cardsHtml: string = "HELP";
  availableModels = ["City", "House", "Flat", "Citizen"];
  control = new FormControl(this.availableModels[0]);
  form = new FormGroup({
    food: this.control
  });
}


