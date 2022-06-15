import { IQueryParams } from "./interfaces";

export type HazardousContext = {
  hazardousAsteroidsData: HazardousAsteroidsResponse;
  getHazardousAsteroids: (params: IQueryParams) => void;
};

export type HazardousAsteroid = {
  name: string;
  diameter: number;
  speed: number;
  date: Date;
};

export type HazardousAsteroidsResponse = {
  totalItemsCount: number;
  hazardousAsteroids: HazardousAsteroid[];
};
