import { HazardousAsteroidsActions } from "../types";

export interface IHazardousAsteroidsAction {
  type: HazardousAsteroidsActions;
  payload: any;
}

export interface IHazardousAsteroidsState {
  hazardousAsteroids: IHazardousAsteroid[];
}

export interface IHazardousAsteroid {
  name: string;
  diameter: number;
  speed: number;
  date: Date;
}
