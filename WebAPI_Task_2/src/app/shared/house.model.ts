import {City} from "./city.model";
import {AbstractModel} from "./abstract.model";

/**
 * Flat model
 */
export interface House extends AbstractModel
{
  streetName: string;
  houseNumber: string;
  city: City;
  floorsNumber: number;
}
