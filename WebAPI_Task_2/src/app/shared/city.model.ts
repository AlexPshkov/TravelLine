import {AbstractModel} from "./abstract.model";

/**
 * City model
 */
export interface City extends AbstractModel
{
  country: string;
  region: string;
  cityName: string;
}
