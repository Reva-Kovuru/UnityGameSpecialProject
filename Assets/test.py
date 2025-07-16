import json
import pandas as pd
import os

filenum = 0
base_path = "c:\\Users\\kreva\\Desktop\\Unity Projects\\My project (4)\\letssee\\Assets\\DataLoggerJSON_"
ext_json = ".json"

main_df = pd.DataFrame()

while True:
    file_path = base_path + str(filenum) + ext_json
    if not os.path.exists(file_path):
        break  # Exit the loop if the file does not exist

    with open(file_path, 'r') as file:
        data = json.load(file)

    df = pd.DataFrame({
        "bullets_per_second": data["bulletsPerSecond"],
        "enemy_kills_per_second": data["enemyKillsPerSecond"]
    })

    main_df = pd.concat([main_df, df], ignore_index=True)

    filenum += 1

summary = main_df.describe(percentiles=[0.25, 0.5, 0.75])

def classify(row):
    if row["bullets_per_second"] > row["enemy_kills_per_second"]:
        return 1
    else:
        return 0

df["classification"] = df.apply(classify, axis=1)
if df["classification"].sum() > 0:
    print("offensive")