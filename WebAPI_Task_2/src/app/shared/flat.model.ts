import {AbstractModel} from "./abstract.model";
import {House} from "./house.model";

/**
 * Flat model
 */
export interface Flat extends AbstractModel
{
  house: House;
  flatNumber: number;
}
