import { createContext } from "react";
import { IQueryParams } from "./interfaces";
import { HazardousContext } from "./types";

const hazardousAsteroidsContext = createContext<HazardousContext>({
  hazardousAsteroidsData: { totalItemsCount: 0, hazardousAsteroids: [] },
  getHazardousAsteroids: (params: IQueryParams) => {},
});

export default hazardousAsteroidsContext;
