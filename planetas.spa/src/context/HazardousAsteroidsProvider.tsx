import { FC, ReactNode, useReducer } from "react";
import HazardousAsteroidsContext from "./hazardousAsteroidsContext";
import hazardousAsteroidsReducer from "./hazardousAsteroidsReducer";
import { HazardousAsteroidsActions } from "../types";
import { IHazardousAsteroidsState, IQueryParams } from "./interfaces";
// import hazardousAsteroidsClient from "../config/axios";
import { data } from "./hazardousDataMock";

interface Props {
  children: ReactNode;
}

const HazardousAsteroidsProvider: FC<Props> = ({ children }) => {
  const initialState: IHazardousAsteroidsState = {
    hazardousAsteroidsData: { totalItemsCount: 0, hazardousAsteroids: [] },
  };

  const [state, dispatch] = useReducer(hazardousAsteroidsReducer, initialState);

  const getHazardousAsteroids = async (params: IQueryParams) => {
    try {
      // const result = await hazardousAsteroidsClient.get(
      //   "/HazardousAsteroids/ByDate",
      //   {
      //     headers: {
      //       accept: "*/*",
      //     },
      //     params,
      //   }
      // );

      dispatch({
        type: HazardousAsteroidsActions.GET_HAZARDOUS_ASTEROIDS,
        // payload: result.data,
        payload: data,
      });
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <HazardousAsteroidsContext.Provider
      value={{
        hazardousAsteroidsData: state.hazardousAsteroidsData,
        getHazardousAsteroids,
      }}
    >
      {children}
    </HazardousAsteroidsContext.Provider>
  );
};

export default HazardousAsteroidsProvider;
