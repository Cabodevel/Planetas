import { Context, useContext } from "react";

export const useContextOrError = <ItemType>(
  context: Context<ItemType>
): ItemType => {
  const contextValue = useContext(context);
  if (!contextValue) {
    throw Error("Context has not been Provided!");
  }
  return contextValue;
};
