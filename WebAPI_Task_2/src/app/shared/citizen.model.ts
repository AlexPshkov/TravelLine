import {AbstractModel} from "./abstract.model";
import {Flat} from "./flat.model";

/**
 * Citizen model
 */
export interface Citizen extends AbstractModel
{
  flat: Flat
  firstName: string;
  lastName: string;
}
