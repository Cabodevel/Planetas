import { HazardousAsteroidsActions } from "../types";
import {
  IHazardousAsteroidsState,
  IHazardousAsteroidsAction,
} from "./interfaces";

const reducer = (
  state: IHazardousAsteroidsState,
  action: IHazardousAsteroidsAction
) => {
  switch (action.type) {
    case HazardousAsteroidsActions.GET_HAZARDOUS_ASTEROIDS:
      return {
        ...state,
        hazardousAsteroids: action.payload,
      };
    default:
      return state;
  }
};

export default reducer;
