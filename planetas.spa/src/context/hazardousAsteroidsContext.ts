import { createContext } from "react";
import { HazardousContext } from "./types";

const hazardousAsteroidsContext = createContext<HazardousContext>({
  hazardousAsteroids: [],
  getHazardousAsteroids: () => {},
});

export default hazardousAsteroidsContext;
