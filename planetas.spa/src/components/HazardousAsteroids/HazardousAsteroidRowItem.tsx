import { FC } from "react";
import { HazardousAsteroid } from "../../context/types";

interface Props {
  hazardousAsteroid: HazardousAsteroid;
}

const HazardousAsteroidRowItem: FC<Props> = ({ hazardousAsteroid }) => {
  return (
    <tr>
      <td>{hazardousAsteroid.name}</td>
      <td>{hazardousAsteroid.diameter}</td>
      <td>{hazardousAsteroid.speed}</td>
      <td>{hazardousAsteroid.date.toString()}</td>
    </tr>
  );
};

export default HazardousAsteroidRowItem;
