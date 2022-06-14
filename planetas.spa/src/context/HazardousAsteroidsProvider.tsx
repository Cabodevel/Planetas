import { FC, ReactNode, useReducer } from "react";
import hazardousAsteroidsClient from "../config/axios";
import HazardousAsteroidsContext from "./hazardousAsteroidsContext";
import hazardousAsteroidsReducer from "./hazardousAsteroidsReducer";
import { HazardousAsteroidsActions } from "../types";
import { IHazardousAsteroidsState } from "./interfaces";

interface Props {
  children: ReactNode;
}

const HazardousAsteroidsProvider: FC<Props> = ({ children }) => {
  const initialState: IHazardousAsteroidsState = {
    hazardousAsteroids: [],
  };

  const [state, dispatch] = useReducer(hazardousAsteroidsReducer, initialState);

  const getHazardousAsteroids = async () => {
    try {
      debugger;
      const result = await hazardousAsteroidsClient.get(
        "/HazardousAsteroids/ByDate?planetName=Earth"
      );

      dispatch({
        type: HazardousAsteroidsActions.GET_HAZARDOUS_ASTEROIDS,
        payload: result,
      });
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <HazardousAsteroidsContext.Provider
      value={{
        hazardousAsteroids: state.hazardousAsteroids,
        getHazardousAsteroids,
      }}
    >
      {children}
    </HazardousAsteroidsContext.Provider>
  );
};

export default HazardousAsteroidsProvider;
