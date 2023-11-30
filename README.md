# MocopiIdentification
createBy boichi(so-mimi)

## What is MocopiIdentification?
mocopiを使用して様々な全身の動きを識別するツール

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

入力の例（今は別なので直す）
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
「作成したCSVファイルを選択」を押して、
