# MocopiIdentification
createBy boichi(so-mimi)

## What is MocopiIdentification?
mocopiを使用して様々な全身の動きを識別するツール
※Windowsのみ

・モーションを記録する

・記録したモーションからONNXを作成する

・Unityで使用する

の3つの段階を経て使用できます。

## Introduction
https://github.com/so-mimi/MocopiIdentification/releases

このリンクに飛んで、

![スクリーンショット 2023-11-30 103559](https://github.com/so-mimi/MocopiIdentification/assets/91968626/09d931df-f661-4822-abe0-0b09aa02d9cd)

この中で、MakeMotionData.zip、MotionIdentificationAI.unitypackage、advanced_model、MocopiAICreater.zipの4つをダウンロードしてください

### MakeMotionData
まずMakeMotionDataのzipを解凍して、

![スクリーンショット 2023-11-30 093753](https://github.com/so-mimi/MocopiIdentification/assets/91968626/acaf4b94-1a70-402a-8bca-7818948e0296)

この中のMakeMotionData.exeを実行してください。
もしPCが保護されました、と出たら、詳細情報→実行するの順に押してください

![スクリーンショット 2023-11-30 094030](https://github.com/so-mimi/MocopiIdentification/assets/91968626/6fcb1e63-fa69-4731-be3b-7f452eb102a1)

開くと上のような画面になると思います。
mocopiアプリの設定にこれらの情報を入力します。

参考
https://www.sony.net/Products/mocopi-dev/jp/documents/ReceiverPlugin/SendData.html

そしてmocopiアプリから送信ができると、右側のアバターがmocopiを着用した人の動きを再現するようになります。

また、保存したデータを格納するファイルのパスを記入してください。
例 C:\MotionData

そしたら次へを押して指示に沿って進んでください。

入力の例

https://www.youtube.com/watch?v=l4jItfOTs4s&list=RDl4jItfOTs4s&start_radio=1

すべて終えると、適切なcsvファイルが指定したファイルに生成されます。

### MocopiAICreater
生成したcsvファイルからONNX形式のニューラルネットワークを生成します。

まずAI作成の準備として、生成したcsvと同じ階層に解凍したadvanced_modelファイルを配置してください。

![スクリーンショット 2023-11-30 104000](https://github.com/so-mimi/MocopiIdentification/assets/91968626/9e1c148c-0a79-4487-9baf-37c1b8fda52d)


次にMocopiAICreaterを解凍します。

解凍したファイルの中にあるMocopiAICreater.exeを実行します。
コマンドプロンプトが現れ、1～2分ほど待つと、

![スクリーンショット 2023-11-30 104054](https://github.com/so-mimi/MocopiIdentification/assets/91968626/eb46ecb5-36bc-4d34-a9bc-603493bd1a97)

このような画面が出ます。
「作成したCSVファイルを選択」を押して、先ほど生成したcsvを選択すると、UIが消えて、コマンド上で処理が見えます。

![スクリーンショット 2023-11-30 104105](https://github.com/so-mimi/MocopiIdentification/assets/91968626/ca9df52b-314c-4f2e-8843-2a62b03f4b9d)

10分ほど画面を放置し、コマンドプロンプトが自動的に終了したら完了です。csvファイルと同じ階層に
mocopiAI.onnxというものが生成されます。

![スクリーンショット 2023-11-30 105108](https://github.com/so-mimi/MocopiIdentification/assets/91968626/7c1e8381-0317-419d-b5ee-8c3f40f1bd79)

### Unity上で実行する
デバッグ環境はUnity 2021.3.24f1です。

Unityプロジェクトを新たに3Dで立ち上げます。

![スクリーンショット 2023-11-30 105628](https://github.com/so-mimi/MocopiIdentification/assets/91968626/7624cb95-8dbd-47d1-99f6-981d9a0228c5)

まず最初にUnity向けのmocopiSDKをインポートします。
https://www.sony.net/Products/mocopi-dev/jp/downloads/DownloadInfo.html#Unity_Plugin

ダウンロードしたファイルの中にあるUnityPackageをインポートします

その後、シーン内に

![スクリーンショット 2023-11-30 110100 (1)](https://github.com/so-mimi/MocopiIdentification/assets/91968626/33bf05f4-0a66-4474-a422-c919efbff934)

![スクリーンショット 2023-11-30 110048 (1)](https://github.com/so-mimi/MocopiIdentification/assets/91968626/d3b8ac70-69a2-4f0a-8c56-75076b8df2b3)

このようにプレハブとコンポーネントを配置してください。

次に、UniRxと11/30日現在β版のUnity Sentisをいれてください。

UniRx参考記事
https://qiita.com/S4ch1mos/items/162767fa59296f74ced0

Unity Sentis記事
https://zenn.dev/boichi/articles/268cf603991e7f

その後、一番最初にダウンロードしたMotionIdentificationA.unitypackageをインポートしてください。

その後、以下のようにモデルに直接2つのコンポーネントをアタッチしてください。

![スクリーンショット 2023-11-30 110538](https://github.com/so-mimi/MocopiIdentification/assets/91968626/d231b23a-49dd-4f32-a4cf-3f4cba93e237)

次にONNXファイルをいれて、MotionDitectionAIコンポーネントにアタッチしてください。

![スクリーンショット 2023-11-30 110644](https://github.com/so-mimi/MocopiIdentification/assets/91968626/6110a03a-c349-41b9-832f-fd73aa5de7f2)

Unityとmocopiアバターがリンクしたら数値が動きます！
数値の例

https://youtu.be/nBXq06g7S20



