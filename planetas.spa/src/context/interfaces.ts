import { HazardousAsteroidsActions } from "../types";
import { HazardousAsteroidsResponse } from "./types";

export interface IHazardousAsteroidsAction {
  type: HazardousAsteroidsActions;
  payload: any;
}

export interface IHazardousAsteroidsState {
  hazardousAsteroidsData: HazardousAsteroidsResponse;
}

export interface IHazardousAsteroid {
  name: string;
  diameter: number;
  speed: number;
  date: Date;
}

export interface IQueryParams {
  planetName: string;
  fromDate?: Date;
  toDate?: Date;
  pageNumber?: number;
  pageSize?: number;
}
