﻿using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CefSharp;
using System.Diagnostics;
using System.Collections.Generic;
using Subtitle;

namespace Jamaker
{
    public partial class MainForm : Form
    {
        private string settingJson = "{\"from\":\"<Sync Start=138425><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">光</FONT><FONT color=\\\"#0066EE\\\">を目指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=138628><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">光</FONT><FONT color=\\\"#0066EE\\\">を目指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=139163><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光</FONT><FONT color=\\\"#0066EE\\\">を</FONT><FONT color=\\\"#0066EE\\\">目指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=139306><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を</FONT><FONT color=\\\"#0066EE\\\">目</FONT><FONT color=\\\"#0066EE\\\">指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=139836><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目</FONT><FONT color=\\\"#0066EE\\\">指</FONT><FONT color=\\\"#0066EE\\\">して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=139961><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指</FONT><FONT color=\\\"#0066EE\\\">し</FONT><FONT color=\\\"#0066EE\\\">て生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=140467><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指し</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=140603><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して</FONT><FONT color=\\\"#0066EE\\\">生</FONT><FONT color=\\\"#0066EE\\\">まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=141205><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生</FONT><FONT color=\\\"#0066EE\\\">ま</FONT><FONT color=\\\"#0066EE\\\">れてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=141360><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生ま</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">てきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=141685><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生まれ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">きた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=141823><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生まれて</FONT><FONT color=\\\"#0066EE\\\">き</FONT><FONT color=\\\"#0066EE\\\">た</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=142172><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生まれてき</FONT><FONT color=\\\"#0066EE\\\">た</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=142308><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=143342><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">絆</FONT><FONT color=\\\"#0066EE\\\">　細い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=143702><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">絆</FONT><FONT color=\\\"#0066EE\\\">　細い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=143847><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　</FONT><FONT color=\\\"#0066EE\\\">細</FONT><FONT color=\\\"#0066EE\\\">い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145049><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　</FONT><FONT color=\\\"#55AAF6\\\">細</FONT><FONT color=\\\"#0066EE\\\">い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145417><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細</FONT><FONT color=\\\"#0066EE\\\">い</FONT><FONT color=\\\"#0066EE\\\">糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145570><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い</FONT><FONT color=\\\"#0066EE\\\">糸</FONT><FONT color=\\\"#0066EE\\\">に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145728><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い</FONT><FONT color=\\\"#55AAF6\\\">糸</FONT><FONT color=\\\"#0066EE\\\">に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145855><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸</FONT><FONT color=\\\"#0066EE\\\">に</FONT><FONT color=\\\"#0066EE\\\">結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=146345><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に</FONT><FONT color=\\\"#0066EE\\\">結</FONT><FONT color=\\\"#0066EE\\\">ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=146714><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に</FONT><FONT color=\\\"#55AAF6\\\">結</FONT><FONT color=\\\"#0066EE\\\">ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=147146><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に結</FONT><FONT color=\\\"#0066EE\\\">ば</FONT><FONT color=\\\"#0066EE\\\">れて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=147303><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に結ば</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=147641><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に結ばれ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=147780><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=149391><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使</FONT><FONT color=\\\"#0066EE\\\">命</FONT><FONT color=\\\"#0066EE\\\">で目覚めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=149545><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使</FONT><FONT color=\\\"#55AAF6\\\">命</FONT><FONT color=\\\"#0066EE\\\">で目覚めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=150072><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命</FONT><FONT color=\\\"#0066EE\\\">で</FONT><FONT color=\\\"#0066EE\\\">目覚めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=150204><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で</FONT><FONT color=\\\"#0066EE\\\">目</FONT><FONT color=\\\"#0066EE\\\">覚めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=150815><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目</FONT><FONT color=\\\"#0066EE\\\">覚</FONT><FONT color=\\\"#0066EE\\\">めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=150944><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目覚</FONT><FONT color=\\\"#0066EE\\\">め</FONT><FONT color=\\\"#0066EE\\\">た幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=151464><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目覚め</FONT><FONT color=\\\"#0066EE\\\">た</FONT><FONT color=\\\"#0066EE\\\">幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=151600><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目覚めた</FONT><FONT color=\\\"#0066EE\\\">幸</FONT><FONT color=\\\"#0066EE\\\">福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=152177><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目覚めた</FONT><FONT color=\\\"#55AAF6\\\">幸</FONT><FONT color=\\\"#0066EE\\\">福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=152303><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目覚めた幸</FONT><FONT color=\\\"#0066EE\\\">福</FONT><FONT color=\\\"#0066EE\\\">から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=152599><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目覚めた幸</FONT><FONT color=\\\"#55AAF6\\\">福</FONT><FONT color=\\\"#0066EE\\\">から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=152736><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目覚めた幸福</FONT><FONT color=\\\"#0066EE\\\">か</FONT><FONT color=\\\"#0066EE\\\">ら</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=153135><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目覚めた幸福か</FONT><FONT color=\\\"#0066EE\\\">ら</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=153256><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目覚めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=154326><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">紡</FONT><FONT color=\\\"#0066EE\\\">ぐいくつもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=154631><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡</FONT><FONT color=\\\"#0066EE\\\">ぐ</FONT><FONT color=\\\"#0066EE\\\">いくつもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=154783><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ</FONT><FONT color=\\\"#0066EE\\\">い</FONT><FONT color=\\\"#0066EE\\\">くつもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=156055><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐい</FONT><FONT color=\\\"#0066EE\\\">く</FONT><FONT color=\\\"#0066EE\\\">つもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=156422><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいく</FONT><FONT color=\\\"#0066EE\\\">つ</FONT><FONT color=\\\"#0066EE\\\">もの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=156807><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつ</FONT><FONT color=\\\"#0066EE\\\">も</FONT><FONT color=\\\"#0066EE\\\">の誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=156935><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつも</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=157295><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつもの</FONT><FONT color=\\\"#0066EE\\\">誇</FONT><FONT color=\\\"#0066EE\\\">らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=157774><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつもの</FONT><FONT color=\\\"#55AAF6\\\">誇</FONT><FONT color=\\\"#0066EE\\\">らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=158142><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつもの誇</FONT><FONT color=\\\"#0066EE\\\">ら</FONT><FONT color=\\\"#0066EE\\\">しい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=158279><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつもの誇ら</FONT><FONT color=\\\"#0066EE\\\">し</FONT><FONT color=\\\"#0066EE\\\">い記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=158607><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつもの誇らし</FONT><FONT color=\\\"#0066EE\\\">い</FONT><FONT color=\\\"#0066EE\\\">記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=158736><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつもの誇らしい</FONT><FONT color=\\\"#0066EE\\\">記</FONT><FONT color=\\\"#0066EE\\\">憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=159280><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつもの誇らしい記</FONT><FONT color=\\\"#0066EE\\\">憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=159712><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつもの誇らしい記</FONT><FONT color=\\\"#55AAF6\\\">憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=160070><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐいくつもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=160571><P Class=KRCC >\\n&nbsp;\\n<Sync Start=162027><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あ</FONT><FONT color=\\\"#0066EE\\\">な</FONT><FONT color=\\\"#0066EE\\\">たのために</FONT><br>그대를 위해\\n<Sync Start=162192><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あな</FONT><FONT color=\\\"#0066EE\\\">た</FONT><FONT color=\\\"#0066EE\\\">のために</FONT><br>그대를 위해\\n<Sync Start=162369><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなた</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">ために</FONT><br>그대를 위해\\n<Sync Start=162546><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなたの</FONT><FONT color=\\\"#0066EE\\\">た</FONT><FONT color=\\\"#0066EE\\\">めに</FONT><br>그대를 위해\\n<Sync Start=162728><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなたのた</FONT><FONT color=\\\"#0066EE\\\">め</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>그대를 위해\\n<Sync Start=162896><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなたのため</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>그대를 위해\\n<Sync Start=163105><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなたのために</FONT><br>그대를 위해\\n<Sync Start=164743><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">こ</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">世界へ感謝と</FONT><br>이 세계에 감사와\\n<Sync Start=164921><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この</FONT><FONT color=\\\"#0066EE\\\">世</FONT><FONT color=\\\"#0066EE\\\">界へ感謝と</FONT><br>이 세계에 감사와\\n<Sync Start=165098><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世</FONT><FONT color=\\\"#0066EE\\\">界</FONT><FONT color=\\\"#0066EE\\\">へ感謝と</FONT><br>이 세계에 감사와\\n<Sync Start=165265><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世</FONT><FONT color=\\\"#55AAF6\\\">界</FONT><FONT color=\\\"#0066EE\\\">へ感謝と</FONT><br>이 세계에 감사와\\n<Sync Start=165423><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世界</FONT><FONT color=\\\"#0066EE\\\">へ</FONT><FONT color=\\\"#0066EE\\\">感謝と</FONT><br>이 세계에 감사와\\n<Sync Start=165803><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世界へ</FONT><FONT color=\\\"#0066EE\\\">感</FONT><FONT color=\\\"#0066EE\\\">謝と</FONT><br>이 세계에 감사와\\n<Sync Start=166019><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世界へ</FONT><FONT color=\\\"#55AAF6\\\">感</FONT><FONT color=\\\"#0066EE\\\">謝と</FONT><br>이 세계에 감사와\\n<Sync Start=166169><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世界へ感</FONT><FONT color=\\\"#0066EE\\\">謝</FONT><FONT color=\\\"#0066EE\\\">と</FONT><br>이 세계에 감사와\\n<Sync Start=166427><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世界へ感謝</FONT><FONT color=\\\"#0066EE\\\">と</FONT><br>이 세계에 감사와\\n<Sync Start=166540><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世界へ感謝と</FONT><br>이 세계에 감사와\\n<Sync Start=167514><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇</FONT><FONT color=\\\"#0066EE\\\">宙</FONT><FONT color=\\\"#0066EE\\\">一杯の</FONT><br>우주 한가득인\\n<Sync Start=167888><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇</FONT><FONT color=\\\"#55AAF6\\\">宙</FONT><FONT color=\\\"#0066EE\\\">一杯の</FONT><br>우주 한가득인\\n<Sync Start=168298><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙</FONT><FONT color=\\\"#0066EE\\\">一</FONT><FONT color=\\\"#0066EE\\\">杯の</FONT><br>우주 한가득인\\n<Sync Start=168690><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙</FONT><FONT color=\\\"#55AAF6\\\">一</FONT><FONT color=\\\"#0066EE\\\">杯の</FONT><br>우주 한가득인\\n<Sync Start=168961><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙一</FONT><FONT color=\\\"#0066EE\\\">杯</FONT><FONT color=\\\"#0066EE\\\">の</FONT><br>우주 한가득인\\n<Sync Start=169562><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙一</FONT><FONT color=\\\"#55AAF6\\\">杯</FONT><FONT color=\\\"#0066EE\\\">の</FONT><br>우주 한가득인\\n<Sync Start=169730><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙一杯</FONT><FONT color=\\\"#0066EE\\\">の</FONT><br>우주 한가득인\\n<Sync Start=169915><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙一杯の</FONT><br>우주 한가득인\\n<Sync Start=171587><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">花</FONT><FONT color=\\\"#0066EE\\\">束を</FONT><br>꽃다발을\\n<Sync Start=171699><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">花</FONT><FONT color=\\\"#0066EE\\\">束</FONT><FONT color=\\\"#0066EE\\\">を</FONT><br>꽃다발을\\n<Sync Start=172065><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">花</FONT><FONT color=\\\"#55AAF6\\\">束</FONT><FONT color=\\\"#0066EE\\\">を</FONT><br>꽃다발을\\n<Sync Start=172402><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">花束</FONT><FONT color=\\\"#0066EE\\\">を</FONT><br>꽃다발을\\n<Sync Start=172730><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">花束を</FONT><br>꽃다발을\\n<Sync Start=173596><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">宿</FONT><FONT color=\\\"#0066EE\\\">命さえ運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=173881><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿</FONT><FONT color=\\\"#0066EE\\\">命</FONT><FONT color=\\\"#0066EE\\\">さえ運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=174244><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿</FONT><FONT color=\\\"#55AAF6\\\">命</FONT><FONT color=\\\"#0066EE\\\">さえ運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=174402><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命</FONT><FONT color=\\\"#0066EE\\\">さ</FONT><FONT color=\\\"#0066EE\\\">え運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=174561><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さ</FONT><FONT color=\\\"#0066EE\\\">え</FONT><FONT color=\\\"#0066EE\\\">運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=174715><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ</FONT><FONT color=\\\"#0066EE\\\">運</FONT><FONT color=\\\"#0066EE\\\">命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=175261><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ</FONT><FONT color=\\\"#55AAF6\\\">運</FONT><FONT color=\\\"#0066EE\\\">命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=175434><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ運</FONT><FONT color=\\\"#0066EE\\\">命</FONT><FONT color=\\\"#0066EE\\\">さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=175617><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ運</FONT><FONT color=\\\"#55AAF6\\\">命</FONT><FONT color=\\\"#0066EE\\\">さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=175769><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ運命</FONT><FONT color=\\\"#0066EE\\\">さ</FONT><FONT color=\\\"#0066EE\\\">えも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=176121><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ運命さ</FONT><FONT color=\\\"#0066EE\\\">え</FONT><FONT color=\\\"#0066EE\\\">も</FONT><br>숙명마저, 운명마저도\\n<Sync Start=176263><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ運命さえ</FONT><FONT color=\\\"#0066EE\\\">も</FONT><br>숙명마저, 운명마저도\\n<Sync Start=176630><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=177020><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">ど</FONT><FONT color=\\\"#0066EE\\\">う</FONT><FONT color=\\\"#0066EE\\\">ぞ輝かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=177200><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どう</FONT><FONT color=\\\"#0066EE\\\">ぞ</FONT><FONT color=\\\"#0066EE\\\">輝かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=177508><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ</FONT><FONT color=\\\"#0066EE\\\">輝</FONT><FONT color=\\\"#0066EE\\\">かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=177917><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ</FONT><FONT color=\\\"#3893F3\\\">輝</FONT><FONT color=\\\"#0066EE\\\">かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=178083><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ</FONT><FONT color=\\\"#71C0F9\\\">輝</FONT><FONT color=\\\"#0066EE\\\">かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=178235><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ輝</FONT><FONT color=\\\"#0066EE\\\">か</FONT><FONT color=\\\"#0066EE\\\">せて</FONT><br>부디 빛나게 해줘\\n<Sync Start=178396><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ輝か</FONT><FONT color=\\\"#0066EE\\\">せ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><br>부디 빛나게 해줘\\n<Sync Start=178883><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ輝かせ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><br>부디 빛나게 해줘\\n<Sync Start=179011><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ輝かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=179628><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">楽</FONT><FONT color=\\\"#0066EE\\\">しんだり笑うのを守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=179938><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽</FONT><FONT color=\\\"#0066EE\\\">し</FONT><FONT color=\\\"#0066EE\\\">んだり笑うのを守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180095><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽し</FONT><FONT color=\\\"#0066EE\\\">ん</FONT><FONT color=\\\"#0066EE\\\">だり笑うのを守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180252><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しん</FONT><FONT color=\\\"#0066EE\\\">だ</FONT><FONT color=\\\"#0066EE\\\">り笑うのを守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180419><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだ</FONT><FONT color=\\\"#0066EE\\\">り</FONT><FONT color=\\\"#0066EE\\\">笑うのを守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180563><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり</FONT><FONT color=\\\"#0066EE\\\">笑</FONT><FONT color=\\\"#0066EE\\\">うのを守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180966><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり</FONT><FONT color=\\\"#55AAF6\\\">笑</FONT><FONT color=\\\"#0066EE\\\">うのを守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=181315><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑</FONT><FONT color=\\\"#0066EE\\\">う</FONT><FONT color=\\\"#0066EE\\\">のを守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=181475><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑う</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">を守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=181787><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うの</FONT><FONT color=\\\"#0066EE\\\">を</FONT><FONT color=\\\"#0066EE\\\">守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=181940><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うのを</FONT><FONT color=\\\"#0066EE\\\">守</FONT><FONT color=\\\"#0066EE\\\">れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=182304><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うのを</FONT><FONT color=\\\"#55AAF6\\\">守</FONT><FONT color=\\\"#0066EE\\\">れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=182654><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うのを守</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">る喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=182813><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うのを守れ</FONT><FONT color=\\\"#0066EE\\\">る</FONT><FONT color=\\\"#0066EE\\\">喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=182982><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うのを守れる</FONT><FONT color=\\\"#0066EE\\\">喜</FONT><FONT color=\\\"#0066EE\\\">び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=183149><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うのを守れる</FONT><FONT color=\\\"#3893F3\\\">喜</FONT><FONT color=\\\"#0066EE\\\">び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=183318><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うのを守れる</FONT><FONT color=\\\"#71C0F9\\\">喜</FONT><FONT color=\\\"#0066EE\\\">び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=183494><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うのを守れる喜</FONT><FONT color=\\\"#0066EE\\\">び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=183652><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">楽しんだり笑うのを守れる喜び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=184627><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れてる</FONT><br>동경하고 있어\\n<Sync Start=184907><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れてる</FONT><br>동경하고 있어\\n<Sync Start=185243><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">てる</FONT><br>동경하고 있어\\n<Sync Start=185414><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>동경하고 있어\\n<Sync Start=185571><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れて</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>동경하고 있어\\n<Sync Start=185755><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れてる</FONT><br>동경하고 있어\\n<Sync Start=186244><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れてる</FONT><br>동경하고 있어\\n<Sync Start=186404><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れてる</FONT><br>동경하고 있어\\n<Sync Start=186571><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">てる</FONT><br>동경하고 있어\\n<Sync Start=186747><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>동경하고 있어\\n<Sync Start=187099><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れて</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>동경하고 있어\\n<Sync Start=187525><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れてる</FONT><br>동경하고 있어\\n<Sync Start=187964><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">も</FONT><FONT color=\\\"#0066EE\\\">っ</FONT><FONT color=\\\"#0066EE\\\">と強くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=188109><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっ</FONT><FONT color=\\\"#0066EE\\\">と</FONT><FONT color=\\\"#0066EE\\\">強くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=188510><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと</FONT><FONT color=\\\"#0066EE\\\">強</FONT><FONT color=\\\"#0066EE\\\">くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=188903><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと</FONT><FONT color=\\\"#55AAF6\\\">強</FONT><FONT color=\\\"#0066EE\\\">くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189061><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強</FONT><FONT color=\\\"#0066EE\\\">く</FONT><FONT color=\\\"#0066EE\\\">なれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189221><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強く</FONT><FONT color=\\\"#0066EE\\\">な</FONT><FONT color=\\\"#0066EE\\\">れる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189357><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強くな</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189822><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強くなれ</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189957><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=190551><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴</FONT><FONT color=\\\"#0066EE\\\">き</FONT><FONT color=\\\"#0066EE\\\">声さえ歌のように聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=190919><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き</FONT><FONT color=\\\"#0066EE\\\">声</FONT><FONT color=\\\"#0066EE\\\">さえ歌のように聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191087><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き</FONT><FONT color=\\\"#55AAF6\\\">声</FONT><FONT color=\\\"#0066EE\\\">さえ歌のように聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191224><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声</FONT><FONT color=\\\"#0066EE\\\">さ</FONT><FONT color=\\\"#0066EE\\\">え歌のように聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191415><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さ</FONT><FONT color=\\\"#0066EE\\\">え</FONT><FONT color=\\\"#0066EE\\\">歌のように聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191607><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ</FONT><FONT color=\\\"#0066EE\\\">歌</FONT><FONT color=\\\"#0066EE\\\">のように聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191904><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ</FONT><FONT color=\\\"#55AAF6\\\">歌</FONT><FONT color=\\\"#0066EE\\\">のように聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=192264><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">ように聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=192422><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌の</FONT><FONT color=\\\"#0066EE\\\">よ</FONT><FONT color=\\\"#0066EE\\\">うに聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=192715><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のよ</FONT><FONT color=\\\"#0066EE\\\">う</FONT><FONT color=\\\"#0066EE\\\">に聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=192874><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のよう</FONT><FONT color=\\\"#0066EE\\\">に</FONT><FONT color=\\\"#0066EE\\\">聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193018><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のように</FONT><FONT color=\\\"#0066EE\\\">聞</FONT><FONT color=\\\"#0066EE\\\">かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193306><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のように聞</FONT><FONT color=\\\"#0066EE\\\">か</FONT><FONT color=\\\"#0066EE\\\">せてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193626><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のように聞か</FONT><FONT color=\\\"#0066EE\\\">せ</FONT><FONT color=\\\"#0066EE\\\">てあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193780><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のように聞かせ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">あげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193940><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のように聞かせて</FONT><FONT color=\\\"#0066EE\\\">あ</FONT><FONT color=\\\"#0066EE\\\">げたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=194099><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のように聞かせてあ</FONT><FONT color=\\\"#0066EE\\\">げ</FONT><FONT color=\\\"#0066EE\\\">たい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=194275><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のように聞かせてあげ</FONT><FONT color=\\\"#0066EE\\\">た</FONT><FONT color=\\\"#0066EE\\\">い</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=194442><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のように聞かせてあげた</FONT><FONT color=\\\"#0066EE\\\">い</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=194610><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">鳴き声さえ歌のように聞かせてあげたい</FONT><br>우는 소리조차 노래처럼 들려주고 싶어\\n<Sync Start=195864><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">こ</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">目くるめく時間に</FONT><br>이 아득한 시간에\\n<Sync Start=196245><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この</FONT><FONT color=\\\"#0066EE\\\">目</FONT><FONT color=\\\"#0066EE\\\">くるめく時間に</FONT><br>이 아득한 시간에\\n<Sync Start=197280><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目</FONT><FONT color=\\\"#0066EE\\\">く</FONT><FONT color=\\\"#0066EE\\\">るめく時間に</FONT><br>이 아득한 시간에\\n<Sync Start=197570><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目く</FONT><FONT color=\\\"#0066EE\\\">る</FONT><FONT color=\\\"#0066EE\\\">めく時間に</FONT><br>이 아득한 시간에\\n<Sync Start=197904><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目くる</FONT><FONT color=\\\"#0066EE\\\">め</FONT><FONT color=\\\"#0066EE\\\">く時間に</FONT><br>이 아득한 시간에\\n<Sync Start=198033><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目くるめ</FONT><FONT color=\\\"#0066EE\\\">く</FONT><FONT color=\\\"#0066EE\\\">時間に</FONT><br>이 아득한 시간에\\n<Sync Start=198409><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目くるめく</FONT><FONT color=\\\"#0066EE\\\">時</FONT><FONT color=\\\"#0066EE\\\">間に</FONT><br>이 아득한 시간에\\n<Sync Start=198894><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目くるめく時</FONT><FONT color=\\\"#0066EE\\\">間</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>이 아득한 시간에\\n<Sync Start=199193><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目くるめく時</FONT><FONT color=\\\"#55AAF6\\\">間</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>이 아득한 시간에\\n<Sync Start=199526><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目くるめく時間</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>이 아득한 시간에\\n<Sync Start=199910><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目くるめく時間に</FONT><br>이 아득한 시간에\\n<Sync Start=200866><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">涙</FONT><FONT color=\\\"#0066EE\\\">まで</FONT><br>눈물까지\\n<Sync Start=201163><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">涙</FONT><FONT color=\\\"#0066EE\\\">まで</FONT><br>눈물까지\\n<Sync Start=201307><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">涙</FONT><FONT color=\\\"#0066EE\\\">ま</FONT><FONT color=\\\"#0066EE\\\">で</FONT><br>눈물까지\\n<Sync Start=201458><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">涙ま</FONT><FONT color=\\\"#0066EE\\\">で</FONT><br>눈물까지\\n<Sync Start=201626><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">涙まで</FONT><br>눈물까지\\n<Sync Start=205425><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">預</FONT><FONT color=\\\"#0066EE\\\">けてほしい</FONT><br>맡겼으면 해\\n<Sync Start=205826><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預</FONT><FONT color=\\\"#0066EE\\\">け</FONT><FONT color=\\\"#0066EE\\\">てほしい</FONT><br>맡겼으면 해\\n<Sync Start=205963><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預け</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">ほしい</FONT><br>맡겼으면 해\\n<Sync Start=206308><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預けて</FONT><FONT color=\\\"#0066EE\\\">ほ</FONT><FONT color=\\\"#0066EE\\\">しい</FONT><br>맡겼으면 해\\n<Sync Start=206676><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預けてほ</FONT><FONT color=\\\"#0066EE\\\">し</FONT><FONT color=\\\"#0066EE\\\">い</FONT><br>맡겼으면 해\\n<Sync Start=207111><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預けてほし</FONT><FONT color=\\\"#0066EE\\\">い</FONT><br>맡겼으면 해\\n<Sync Start=207761><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預けてほしい</FONT><br>맡겼으면 해\",\"to\":\"<Sync Start=122143><P Class=KRCC>\\n정식 가사로 교체하거나 할 때 일괄 치환을 지원합니다.\\n<Sync Start=127482><P Class=KRCC >\\n&nbsp;\\n<Sync Start=138425><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">光</FONT><FONT color=\\\"#0066EE\\\">を目指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=138628><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">光</FONT><FONT color=\\\"#0066EE\\\">を目指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=139163><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光</FONT><FONT color=\\\"#0066EE\\\">を</FONT><FONT color=\\\"#0066EE\\\">目指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=139306><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を</FONT><FONT color=\\\"#0066EE\\\">目</FONT><FONT color=\\\"#0066EE\\\">指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=139836><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目</FONT><FONT color=\\\"#0066EE\\\">指</FONT><FONT color=\\\"#0066EE\\\">して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=139961><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指</FONT><FONT color=\\\"#0066EE\\\">し</FONT><FONT color=\\\"#0066EE\\\">て生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=140467><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指し</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=140603><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して</FONT><FONT color=\\\"#0066EE\\\">生</FONT><FONT color=\\\"#0066EE\\\">まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=141205><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生</FONT><FONT color=\\\"#0066EE\\\">ま</FONT><FONT color=\\\"#0066EE\\\">れてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=141360><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生ま</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">てきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=141685><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生まれ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">きた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=141823><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生まれて</FONT><FONT color=\\\"#0066EE\\\">き</FONT><FONT color=\\\"#0066EE\\\">た</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=142172><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生まれてき</FONT><FONT color=\\\"#0066EE\\\">た</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=142308><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">光を目指して生まれてきた</FONT><br>빛을 꿈꾸며 태어났다네\\n<Sync Start=143342><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">絆</FONT><FONT color=\\\"#0066EE\\\">　細い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=143702><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">絆</FONT><FONT color=\\\"#0066EE\\\">　細い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=143847><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　</FONT><FONT color=\\\"#0066EE\\\">細</FONT><FONT color=\\\"#0066EE\\\">い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145049><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　</FONT><FONT color=\\\"#55AAF6\\\">細</FONT><FONT color=\\\"#0066EE\\\">い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145417><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細</FONT><FONT color=\\\"#0066EE\\\">い</FONT><FONT color=\\\"#0066EE\\\">糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145570><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い</FONT><FONT color=\\\"#0066EE\\\">糸</FONT><FONT color=\\\"#0066EE\\\">に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145728><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い</FONT><FONT color=\\\"#55AAF6\\\">糸</FONT><FONT color=\\\"#0066EE\\\">に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=145855><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸</FONT><FONT color=\\\"#0066EE\\\">に</FONT><FONT color=\\\"#0066EE\\\">結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=146345><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に</FONT><FONT color=\\\"#0066EE\\\">結</FONT><FONT color=\\\"#0066EE\\\">ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=146714><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に</FONT><FONT color=\\\"#55AAF6\\\">結</FONT><FONT color=\\\"#0066EE\\\">ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=147146><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に結</FONT><FONT color=\\\"#0066EE\\\">ば</FONT><FONT color=\\\"#0066EE\\\">れて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=147303><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に結ば</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=147641><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に結ばれ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=147780><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">絆　細い糸に結ばれて</FONT><br>인연은 가는 실로 맺어지고\\n<Sync Start=149391><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使</FONT><FONT color=\\\"#0066EE\\\">命</FONT><FONT color=\\\"#0066EE\\\">で目醒めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=149545><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使</FONT><FONT color=\\\"#55AAF6\\\">命</FONT><FONT color=\\\"#0066EE\\\">で目醒めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=150072><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命</FONT><FONT color=\\\"#0066EE\\\">で</FONT><FONT color=\\\"#0066EE\\\">目醒めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=150204><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で</FONT><FONT color=\\\"#0066EE\\\">目</FONT><FONT color=\\\"#0066EE\\\">醒めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=150815><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目</FONT><FONT color=\\\"#0066EE\\\">醒</FONT><FONT color=\\\"#0066EE\\\">めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=150944><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目醒</FONT><FONT color=\\\"#0066EE\\\">め</FONT><FONT color=\\\"#0066EE\\\">た幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=151464><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目醒め</FONT><FONT color=\\\"#0066EE\\\">た</FONT><FONT color=\\\"#0066EE\\\">幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=151600><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目醒めた</FONT><FONT color=\\\"#0066EE\\\">幸</FONT><FONT color=\\\"#0066EE\\\">福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=152177><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目醒めた</FONT><FONT color=\\\"#55AAF6\\\">幸</FONT><FONT color=\\\"#0066EE\\\">福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=152303><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目醒めた幸</FONT><FONT color=\\\"#0066EE\\\">福</FONT><FONT color=\\\"#0066EE\\\">から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=152599><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目醒めた幸</FONT><FONT color=\\\"#55AAF6\\\">福</FONT><FONT color=\\\"#0066EE\\\">から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=152736><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目醒めた幸福</FONT><FONT color=\\\"#0066EE\\\">か</FONT><FONT color=\\\"#0066EE\\\">ら</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=153135><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目醒めた幸福か</FONT><FONT color=\\\"#0066EE\\\">ら</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=153256><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">使命で目醒めた幸福から</FONT><br>사명으로 깨어난 행복으로\\n<Sync Start=154326><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">紡</FONT><FONT color=\\\"#0066EE\\\">ぐ　幾つもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=154631><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡</FONT><FONT color=\\\"#0066EE\\\">ぐ</FONT><FONT color=\\\"#0066EE\\\">　幾つもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=154783><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　</FONT><FONT color=\\\"#0066EE\\\">幾</FONT><FONT color=\\\"#0066EE\\\">つもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=156055><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　</FONT><FONT color=\\\"#55AAF6\\\">幾</FONT><FONT color=\\\"#0066EE\\\">つもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=156422><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾</FONT><FONT color=\\\"#0066EE\\\">つ</FONT><FONT color=\\\"#0066EE\\\">もの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=156807><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つ</FONT><FONT color=\\\"#0066EE\\\">も</FONT><FONT color=\\\"#0066EE\\\">の誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=156935><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つも</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=157295><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つもの</FONT><FONT color=\\\"#0066EE\\\">誇</FONT><FONT color=\\\"#0066EE\\\">らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=157774><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つもの</FONT><FONT color=\\\"#55AAF6\\\">誇</FONT><FONT color=\\\"#0066EE\\\">らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=158142><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つもの誇</FONT><FONT color=\\\"#0066EE\\\">ら</FONT><FONT color=\\\"#0066EE\\\">しい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=158279><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つもの誇ら</FONT><FONT color=\\\"#0066EE\\\">し</FONT><FONT color=\\\"#0066EE\\\">い記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=158607><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つもの誇らし</FONT><FONT color=\\\"#0066EE\\\">い</FONT><FONT color=\\\"#0066EE\\\">記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=158736><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つもの誇らしい</FONT><FONT color=\\\"#0066EE\\\">記</FONT><FONT color=\\\"#0066EE\\\">憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=159280><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つもの誇らしい記</FONT><FONT color=\\\"#0066EE\\\">憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=159712><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つもの誇らしい記</FONT><FONT color=\\\"#55AAF6\\\">憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=160070><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">紡ぐ　幾つもの誇らしい記憶</FONT><br>엮는 수많은 자랑스러운 기억\\n<Sync Start=160571><P Class=KRCC >\\n&nbsp;\\n<Sync Start=162027><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あ</FONT><FONT color=\\\"#0066EE\\\">な</FONT><FONT color=\\\"#0066EE\\\">たのために</FONT><br>그대를 위해\\n<Sync Start=162192><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あな</FONT><FONT color=\\\"#0066EE\\\">た</FONT><FONT color=\\\"#0066EE\\\">のために</FONT><br>그대를 위해\\n<Sync Start=162369><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなた</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">ために</FONT><br>그대를 위해\\n<Sync Start=162546><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなたの</FONT><FONT color=\\\"#0066EE\\\">た</FONT><FONT color=\\\"#0066EE\\\">めに</FONT><br>그대를 위해\\n<Sync Start=162728><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなたのた</FONT><FONT color=\\\"#0066EE\\\">め</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>그대를 위해\\n<Sync Start=162896><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなたのため</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>그대를 위해\\n<Sync Start=163105><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">あなたのために</FONT><br>그대를 위해\\n<Sync Start=164743><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">こ</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">世界へ</FONT><br>이 세계에\\n<Sync Start=164921><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この</FONT><FONT color=\\\"#0066EE\\\">世</FONT><FONT color=\\\"#0066EE\\\">界へ</FONT><br>이 세계에\\n<Sync Start=165098><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世</FONT><FONT color=\\\"#0066EE\\\">界</FONT><FONT color=\\\"#0066EE\\\">へ</FONT><br>이 세계에\\n<Sync Start=165265><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世</FONT><FONT color=\\\"#55AAF6\\\">界</FONT><FONT color=\\\"#0066EE\\\">へ</FONT><br>이 세계에\\n<Sync Start=165423><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世界</FONT><FONT color=\\\"#0066EE\\\">へ</FONT><br>이 세계에\\n<Sync Start=165803><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この世界へ</FONT><br>이 세계에\\n<Sync Start=166019><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">感</FONT><FONT color=\\\"#0066EE\\\">謝と</FONT><br>감사와\\n<Sync Start=166169><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">感</FONT><FONT color=\\\"#0066EE\\\">謝</FONT><FONT color=\\\"#0066EE\\\">と</FONT><br>감사와\\n<Sync Start=166427><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">感謝</FONT><FONT color=\\\"#0066EE\\\">と</FONT><br>감사와\\n<Sync Start=166540><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">感謝と</FONT><br>감사와\\n<Sync Start=167514><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇</FONT><FONT color=\\\"#0066EE\\\">宙</FONT><FONT color=\\\"#0066EE\\\">いっぱいの</FONT><br>우주 한가득인\\n<Sync Start=167888><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇</FONT><FONT color=\\\"#55AAF6\\\">宙</FONT><FONT color=\\\"#0066EE\\\">いっぱいの</FONT><br>우주 한가득인\\n<Sync Start=168298><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙</FONT><FONT color=\\\"#0066EE\\\">い</FONT><FONT color=\\\"#0066EE\\\">っぱいの</FONT><br>우주 한가득인\\n<Sync Start=168690><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙い</FONT><FONT color=\\\"#0066EE\\\">っ</FONT><FONT color=\\\"#0066EE\\\">ぱいの</FONT><br>우주 한가득인\\n<Sync Start=168961><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙いっ</FONT><FONT color=\\\"#0066EE\\\">ぱ</FONT><FONT color=\\\"#0066EE\\\">いの</FONT><br>우주 한가득인\\n<Sync Start=169562><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙いっぱ</FONT><FONT color=\\\"#0066EE\\\">い</FONT><FONT color=\\\"#0066EE\\\">の</FONT><br>우주 한가득인\\n<Sync Start=169730><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙いっぱい</FONT><FONT color=\\\"#0066EE\\\">の</FONT><br>우주 한가득인\\n<Sync Start=169915><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宇宙いっぱいの</FONT><br>우주 한가득인\\n<Sync Start=171587><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">花</FONT><FONT color=\\\"#0066EE\\\">束を</FONT><br>꽃다발을\\n<Sync Start=171699><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">花</FONT><FONT color=\\\"#0066EE\\\">束</FONT><FONT color=\\\"#0066EE\\\">を</FONT><br>꽃다발을\\n<Sync Start=172065><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">花</FONT><FONT color=\\\"#55AAF6\\\">束</FONT><FONT color=\\\"#0066EE\\\">を</FONT><br>꽃다발을\\n<Sync Start=172402><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">花束</FONT><FONT color=\\\"#0066EE\\\">を</FONT><br>꽃다발을\\n<Sync Start=172730><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">花束を</FONT><br>꽃다발을\\n<Sync Start=173596><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">宿</FONT><FONT color=\\\"#0066EE\\\">命さえ　運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=173881><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿</FONT><FONT color=\\\"#0066EE\\\">命</FONT><FONT color=\\\"#0066EE\\\">さえ　運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=174244><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿</FONT><FONT color=\\\"#55AAF6\\\">命</FONT><FONT color=\\\"#0066EE\\\">さえ　運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=174402><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命</FONT><FONT color=\\\"#0066EE\\\">さ</FONT><FONT color=\\\"#0066EE\\\">え　運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=174561><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さ</FONT><FONT color=\\\"#0066EE\\\">え</FONT><FONT color=\\\"#0066EE\\\">　運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=174715><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ　</FONT><FONT color=\\\"#0066EE\\\">運</FONT><FONT color=\\\"#0066EE\\\">命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=175261><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ　</FONT><FONT color=\\\"#55AAF6\\\">運</FONT><FONT color=\\\"#0066EE\\\">命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=175434><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ　運</FONT><FONT color=\\\"#0066EE\\\">命</FONT><FONT color=\\\"#0066EE\\\">さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=175617><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ　運</FONT><FONT color=\\\"#55AAF6\\\">命</FONT><FONT color=\\\"#0066EE\\\">さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=175769><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ　運命</FONT><FONT color=\\\"#0066EE\\\">さ</FONT><FONT color=\\\"#0066EE\\\">えも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=176121><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ　運命さ</FONT><FONT color=\\\"#0066EE\\\">え</FONT><FONT color=\\\"#0066EE\\\">も</FONT><br>숙명마저, 운명마저도\\n<Sync Start=176263><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ　運命さえ</FONT><FONT color=\\\"#0066EE\\\">も</FONT><br>숙명마저, 운명마저도\\n<Sync Start=176630><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">宿命さえ　運命さえも</FONT><br>숙명마저, 운명마저도\\n<Sync Start=177020><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">ど</FONT><FONT color=\\\"#0066EE\\\">う</FONT><FONT color=\\\"#0066EE\\\">ぞ輝かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=177200><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どう</FONT><FONT color=\\\"#0066EE\\\">ぞ</FONT><FONT color=\\\"#0066EE\\\">輝かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=177508><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ</FONT><FONT color=\\\"#0066EE\\\">輝</FONT><FONT color=\\\"#0066EE\\\">かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=177917><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ</FONT><FONT color=\\\"#3893F3\\\">輝</FONT><FONT color=\\\"#0066EE\\\">かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=178083><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ</FONT><FONT color=\\\"#71C0F9\\\">輝</FONT><FONT color=\\\"#0066EE\\\">かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=178235><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ輝</FONT><FONT color=\\\"#0066EE\\\">か</FONT><FONT color=\\\"#0066EE\\\">せて</FONT><br>부디 빛나게 해줘\\n<Sync Start=178396><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ輝か</FONT><FONT color=\\\"#0066EE\\\">せ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><br>부디 빛나게 해줘\\n<Sync Start=178883><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ輝かせ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><br>부디 빛나게 해줘\\n<Sync Start=179011><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">どうぞ輝かせて</FONT><br>부디 빛나게 해줘\\n<Sync Start=179628><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">愉</FONT><FONT color=\\\"#0066EE\\\">しんだり微笑うのを　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=179938><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉</FONT><FONT color=\\\"#0066EE\\\">し</FONT><FONT color=\\\"#0066EE\\\">んだり微笑うのを　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180095><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉し</FONT><FONT color=\\\"#0066EE\\\">ん</FONT><FONT color=\\\"#0066EE\\\">だり微笑うのを　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180252><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しん</FONT><FONT color=\\\"#0066EE\\\">だ</FONT><FONT color=\\\"#0066EE\\\">り微笑うのを　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180419><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだ</FONT><FONT color=\\\"#0066EE\\\">り</FONT><FONT color=\\\"#0066EE\\\">微笑うのを　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180563><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり</FONT><FONT color=\\\"#0066EE\\\">微</FONT><FONT color=\\\"#0066EE\\\">笑うのを　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=180966><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微</FONT><FONT color=\\\"#0066EE\\\">笑</FONT><FONT color=\\\"#0066EE\\\">うのを　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=181315><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑</FONT><FONT color=\\\"#0066EE\\\">う</FONT><FONT color=\\\"#0066EE\\\">のを　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=181475><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑う</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">を　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=181787><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うの</FONT><FONT color=\\\"#0066EE\\\">を</FONT><FONT color=\\\"#0066EE\\\">　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=181940><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うのを　</FONT><FONT color=\\\"#0066EE\\\">護</FONT><FONT color=\\\"#0066EE\\\">れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=182304><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うのを　</FONT><FONT color=\\\"#55AAF6\\\">護</FONT><FONT color=\\\"#0066EE\\\">れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=182654><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うのを　護</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">る歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=182813><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うのを　護れ</FONT><FONT color=\\\"#0066EE\\\">る</FONT><FONT color=\\\"#0066EE\\\">歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=182982><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うのを　護れる</FONT><FONT color=\\\"#0066EE\\\">歓</FONT><FONT color=\\\"#0066EE\\\">び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=183149><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うのを　護れる</FONT><FONT color=\\\"#3893F3\\\">歓</FONT><FONT color=\\\"#0066EE\\\">び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=183318><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うのを　護れる</FONT><FONT color=\\\"#71C0F9\\\">歓</FONT><FONT color=\\\"#0066EE\\\">び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=183494><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うのを　護れる歓</FONT><FONT color=\\\"#0066EE\\\">び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=183652><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">愉しんだり微笑うのを　護れる歓び</FONT><br>즐겁거나 웃는 걸 지키는 기쁨을\\n<Sync Start=184627><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れてる</FONT><br>동경하고 있어\\n<Sync Start=184907><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れてる</FONT><br>동경하고 있어\\n<Sync Start=185243><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">てる</FONT><br>동경하고 있어\\n<Sync Start=185414><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>동경하고 있어\\n<Sync Start=185571><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れて</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>동경하고 있어\\n<Sync Start=185755><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れてる</FONT><br>동경하고 있어\\n<Sync Start=186244><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れている</FONT><br>동경하고 있어\\n<Sync Start=186404><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れている</FONT><br>동경하고 있어\\n<Sync Start=186571><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">ている</FONT><br>동경하고 있어\\n<Sync Start=186747><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">いる</FONT><br>동경하고 있어\\n<Sync Start=187099><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れて</FONT><FONT color=\\\"#0066EE\\\">い</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>동경하고 있어\\n<Sync Start=187265><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れてい</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>동경하고 있어\\n<Sync Start=187525><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">憧れている</FONT><br>동경하고 있어\\n<Sync Start=187964><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">も</FONT><FONT color=\\\"#0066EE\\\">っ</FONT><FONT color=\\\"#0066EE\\\">と強くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=188109><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっ</FONT><FONT color=\\\"#0066EE\\\">と</FONT><FONT color=\\\"#0066EE\\\">強くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=188510><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと</FONT><FONT color=\\\"#0066EE\\\">強</FONT><FONT color=\\\"#0066EE\\\">くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=188903><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと</FONT><FONT color=\\\"#55AAF6\\\">強</FONT><FONT color=\\\"#0066EE\\\">くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189061><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強</FONT><FONT color=\\\"#0066EE\\\">く</FONT><FONT color=\\\"#0066EE\\\">なれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189221><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強く</FONT><FONT color=\\\"#0066EE\\\">な</FONT><FONT color=\\\"#0066EE\\\">れる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189357><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強くな</FONT><FONT color=\\\"#0066EE\\\">れ</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189822><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強くなれ</FONT><FONT color=\\\"#0066EE\\\">る</FONT><br>더욱 강해질 수 있어\\n<Sync Start=189957><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">もっと強くなれる</FONT><br>더욱 강해질 수 있어\\n<Sync Start=190551><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼</FONT><FONT color=\\\"#0066EE\\\">き</FONT><FONT color=\\\"#0066EE\\\">声さえ　歌のように聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=190919><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き</FONT><FONT color=\\\"#0066EE\\\">声</FONT><FONT color=\\\"#0066EE\\\">さえ　歌のように聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191087><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き</FONT><FONT color=\\\"#55AAF6\\\">声</FONT><FONT color=\\\"#0066EE\\\">さえ　歌のように聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191224><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声</FONT><FONT color=\\\"#0066EE\\\">さ</FONT><FONT color=\\\"#0066EE\\\">え　歌のように聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191415><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さ</FONT><FONT color=\\\"#0066EE\\\">え</FONT><FONT color=\\\"#0066EE\\\">　歌のように聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191607><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　</FONT><FONT color=\\\"#0066EE\\\">歌</FONT><FONT color=\\\"#0066EE\\\">のように聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=191904><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　</FONT><FONT color=\\\"#55AAF6\\\">歌</FONT><FONT color=\\\"#0066EE\\\">のように聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=192264><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">ように聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=192422><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌の</FONT><FONT color=\\\"#0066EE\\\">よ</FONT><FONT color=\\\"#0066EE\\\">うに聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=192715><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のよ</FONT><FONT color=\\\"#0066EE\\\">う</FONT><FONT color=\\\"#0066EE\\\">に聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=192874><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のよう</FONT><FONT color=\\\"#0066EE\\\">に</FONT><FONT color=\\\"#0066EE\\\">聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193018><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のように</FONT><FONT color=\\\"#0066EE\\\">聴</FONT><FONT color=\\\"#0066EE\\\">かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193306><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のように聴</FONT><FONT color=\\\"#0066EE\\\">か</FONT><FONT color=\\\"#0066EE\\\">せてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193626><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のように聴か</FONT><FONT color=\\\"#0066EE\\\">せ</FONT><FONT color=\\\"#0066EE\\\">てあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193780><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のように聴かせ</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">あげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=193940><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のように聴かせて</FONT><FONT color=\\\"#0066EE\\\">あ</FONT><FONT color=\\\"#0066EE\\\">げたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=194099><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のように聴かせてあ</FONT><FONT color=\\\"#0066EE\\\">げ</FONT><FONT color=\\\"#0066EE\\\">たい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=194275><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のように聴かせてあげ</FONT><FONT color=\\\"#0066EE\\\">た</FONT><FONT color=\\\"#0066EE\\\">い</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=194442><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のように聴かせてあげた</FONT><FONT color=\\\"#0066EE\\\">い</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=194610><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">啼き声さえ　歌のように聴かせてあげたい</FONT><br>울음소리조차 노래처럼 들려주고 싶어\\n<Sync Start=195864><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">こ</FONT><FONT color=\\\"#0066EE\\\">の</FONT><FONT color=\\\"#0066EE\\\">目眩く時間に</FONT><br>이 까마득한 시간에\\n<Sync Start=196245><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この</FONT><FONT color=\\\"#0066EE\\\">目</FONT><FONT color=\\\"#0066EE\\\">眩く時間に</FONT><br>이 까마득한 시간에\\n<Sync Start=197280><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目</FONT><FONT color=\\\"#0066EE\\\">眩</FONT><FONT color=\\\"#0066EE\\\">く時間に</FONT><br>이 까마득한 시간에\\n<Sync Start=197570><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目</FONT><FONT color=\\\"#3893F3\\\">眩</FONT><FONT color=\\\"#0066EE\\\">く時間に</FONT><br>이 까마득한 시간에\\n<Sync Start=197904><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目</FONT><FONT color=\\\"#71C0F9\\\">眩</FONT><FONT color=\\\"#0066EE\\\">く時間に</FONT><br>이 까마득한 시간에\\n<Sync Start=198033><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目眩</FONT><FONT color=\\\"#0066EE\\\">く</FONT><FONT color=\\\"#0066EE\\\">時間に</FONT><br>이 까마득한 시간에\\n<Sync Start=198409><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目眩く</FONT><FONT color=\\\"#0066EE\\\">時</FONT><FONT color=\\\"#0066EE\\\">間に</FONT><br>이 까마득한 시간에\\n<Sync Start=198894><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目眩く時</FONT><FONT color=\\\"#0066EE\\\">間</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>이 까마득한 시간에\\n<Sync Start=199193><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目眩く時</FONT><FONT color=\\\"#55AAF6\\\">間</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>이 까마득한 시간에\\n<Sync Start=199526><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目眩く時間</FONT><FONT color=\\\"#0066EE\\\">に</FONT><br>이 까마득한 시간에\\n<Sync Start=199910><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">この目眩く時間に</FONT><br>이 까마득한 시간에\\n<Sync Start=200866><P Class=KRCC>\\n<FONT color=\\\"#3893F3\\\">涙</FONT><FONT color=\\\"#0066EE\\\">まで</FONT><br>눈물까지\\n<Sync Start=201163><P Class=KRCC>\\n<FONT color=\\\"#71C0F9\\\">涙</FONT><FONT color=\\\"#0066EE\\\">まで</FONT><br>눈물까지\\n<Sync Start=201307><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">涙</FONT><FONT color=\\\"#0066EE\\\">ま</FONT><FONT color=\\\"#0066EE\\\">で</FONT><br>눈물까지\\n<Sync Start=201458><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">涙ま</FONT><FONT color=\\\"#0066EE\\\">で</FONT><br>눈물까지\\n<Sync Start=201626><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">涙まで</FONT><br>눈물까지\\n<Sync Start=205425><P Class=KRCC>\\n<FONT color=\\\"#55AAF6\\\">預</FONT><FONT color=\\\"#0066EE\\\">けてほしい</FONT><br>맡겼으면 해\\n<Sync Start=205826><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預</FONT><FONT color=\\\"#0066EE\\\">け</FONT><FONT color=\\\"#0066EE\\\">てほしい</FONT><br>맡겼으면 해\\n<Sync Start=205963><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預け</FONT><FONT color=\\\"#0066EE\\\">て</FONT><FONT color=\\\"#0066EE\\\">ほしい</FONT><br>맡겼으면 해\\n<Sync Start=206308><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預けて</FONT><FONT color=\\\"#0066EE\\\">ほ</FONT><FONT color=\\\"#0066EE\\\">しい</FONT><br>맡겼으면 해\\n<Sync Start=206676><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預けてほ</FONT><FONT color=\\\"#0066EE\\\">し</FONT><FONT color=\\\"#0066EE\\\">い</FONT><br>맡겼으면 해\\n<Sync Start=207111><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預けてほし</FONT><FONT color=\\\"#0066EE\\\">い</FONT><br>맡겼으면 해\\n<Sync Start=207761><P Class=KRCC>\\n<FONT color=\\\"#AAEEFF\\\">預けてほしい</FONT><br>맡겼으면 해\"}";

        public MainForm()
        {
            WebForm("SamiReplacer");

            int[] rect = { 0, 0, 1280, 800 };
            StreamReader sr = null;
            try
            {   // 설정 파일 경로
                sr = new StreamReader("setting/SamiReplacer.txt", Encoding.UTF8);
                string strSetting = sr.ReadToEnd();
                string[] strRect = strSetting.Split(',');
                if (strRect.Length >= 4)
                {
                    rect[0] = Convert.ToInt32(strRect[0]);
                    rect[1] = Convert.ToInt32(strRect[1]);
                    rect[2] = Convert.ToInt32(strRect[2]);
                    rect[3] = Convert.ToInt32(strRect[3]);
                }
                if (strSetting.IndexOf('\n') > 0)
                {
                    settingJson = strSetting.Substring(strSetting.IndexOf('\n') + 1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                rect[0] = (SystemInformation.VirtualScreen.Width - 1280) / 2;
                rect[1] = (SystemInformation.VirtualScreen.Height - 800) / 2;
            }
            finally { sr?.Close(); }

            StartPosition = FormStartPosition.Manual;
            Location = new Point(rect[0], rect[1]);
            Size = new Size(rect[2], rect[3]);

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            AllowTransparency = true;

            mainView.LifeSpanHandler = new LSH(this);
            mainView.LoadUrl(Path.Combine(Directory.GetCurrentDirectory(), "view/SamiReplacer.html"));
            mainView.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            mainView.JavascriptObjectRepository.Register("binder", new Binder(this), false, BindingOptions.DefaultBinder);
            mainView.RequestHandler = new RequestHandler(); // TODO: 팝업에서 이동을 막아야 되는데...

            FormClosing += new FormClosingEventHandler(BeforeExit);
            FormClosed += new FormClosedEventHandler(WebFormClosed);
        }
        public void OverrideInitAfterLoad()
        {
            Script("init", new object[] { settingJson });
        }

        private void BeforeExit(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Script("beforeExit");
        }

        public void ExitAfterSaveSetting(string setting)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ExitAfterSaveSetting(setting); }));
                return;
            }

            StreamWriter sw = null;
            try
            {
                RECT offset = new RECT();
                WinAPI.GetWindowRect(Handle.ToInt32(), ref offset);

                // 설정 폴더 없으면 생성
                DirectoryInfo di = new DirectoryInfo("setting");
                if (!di.Exists)
                {
                    di.Create();
                }

                sw = new StreamWriter("setting/SamiReplacer.txt", false, Encoding.UTF8);
                sw.Write(offset.left + "," + offset.top + "," + (offset.right - offset.left) + "," + (offset.bottom - offset.top) + ",\n" + setting);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sw?.Close();
            }

            Process.GetCurrentProcess().Kill();
        }

        private void WebFormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void OverrideDrop(int x, int y)
        {
            Script("drop", new object[] { x, y });
        }

        public void Compare(string file, string[] froms, string[] tos)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { Compare(file, froms, tos); }));
                return;
            }

            string text = null;
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(file, DetectEncoding(file));
                text = sr.ReadToEnd();
            }
            catch
            {
                Script("alert", "파일을 열지 못했습니다.");
                return;
            }
            finally { sr?.Close(); }

            // TODO

            /*
            Script("showPreview", new object[] { result.PreviewOrigin(), result.PreviewResult() });
            if (result.count == 0)
            {
                Script("alert", new object[] { "치환한 문자열이 없습니다." });
            }
            */
        }
        public void Replace(string[] files, string from, string to)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { Replace(files, from, to); }));
                return;
            }

            if (files.Length == 0)
            {
                Script("alert", new object[] { "파일이 없습니다." });
            }

            List<Smi> originRange = new SmiFile().FromTxt(from).body;
            List<Smi> targetRange = new SmiFile().FromTxt(to  ).body;

            bool hasNewFrameSync = false;
            Dictionary<int, int> matches = new Dictionary<int, int>();
            {
                int i = 0, j = 0;
                for (; j < targetRange.Count; j++)
                {
                    if (targetRange[j].syncType != SyncType.frame)
                        continue;
                    while (i < originRange.Count && originRange[i].start < targetRange[j].start)
                        i++;
                    if (i >= originRange.Count)
                        break;
                    if (originRange[i].syncType != SyncType.frame)
                    {   // 목표 화면 싱크가 원본 화면 싱크와 겹치지 않으면 -1
                        matches.Add(j, -1);
                        hasNewFrameSync = true;
                        continue;
                    }

                    if (originRange[i].start == targetRange[j].start)
                    {   // 목표 화면 싱크가 원본 화면 싱크와 겹치는 경우
                        matches.Add(j, i);
                    }
                    else
                    {   // 목표 화면 싱크가 원본 화면 싱크와 겹치지 않으면 -1
                        matches.Add(j, -1);
                        hasNewFrameSync = true;
                    }
                }
            }
            int success = 0;
            List<string> skips = new List<string>();

            foreach (string file in files)
            {
                Console.WriteLine($"file: {file}");
                Encoding encoding = null;
                string text = null;
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(file, DetectEncoding(file));
                    text = sr.ReadToEnd();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                finally { sr?.Close(); }

                bool isChanged = false;
                SmiFile originSmi = new SmiFile().FromTxt(text);

                int i = 0, shiftIndex = 0, shiftTime = 0;
                for (; i < originSmi.body.Count; i++)
                {
                    if (originSmi.body[i].text.Equals(originRange[0].text))
                    {
                        shiftTime = originSmi.body[i].start - originRange[0].start;
                        Console.WriteLine($"check: {originSmi.body[i].start} - {originRange[0].start}\n{i} / {shiftIndex} / {shiftTime}");
                        bool isCorrect = true;

                        for (shiftIndex = 0; shiftIndex < originRange.Count; shiftIndex++)
                        {
                            if (!originSmi.body[i + shiftIndex].text.Equals(originRange[shiftIndex].text))
                            {
                                Console.WriteLine($"originSmi.body[{i + shiftIndex}]:");
                                Console.WriteLine(originSmi.body[i + shiftIndex].text);
                                Console.WriteLine(originRange[shiftIndex].text);
                                Console.WriteLine("failed");
                                isCorrect = false;
                                break;
                            }

                            if ((originSmi.body[i + shiftIndex].syncType == SyncType.normal) &&
                                (originSmi.body[i + shiftIndex].start != originRange[shiftIndex].start + shiftTime))
                            {
                                isCorrect = false;
                                break;
                            }

                        }

                        if (isCorrect)
                        {
                            isChanged = true;
                            break;
                        }
                    }
                }

                if (!isChanged)
                {
                    skips.Add(file);
                    continue;
                }

                SmiFile targetSmi = new SmiFile()
                {
                    header = originSmi.header,
                    footer = originSmi.footer
                };

                for (int k = 0; k < i; k++)
                {
                    targetSmi.body.Add(originSmi.body[k]);
                }
                for (int k = 0; k < targetRange.Count; k++)
                {
                    if (targetRange[k].syncType == SyncType.frame && matches[k] >= 0)
                        targetSmi.body.Add(new Smi()
                        {   start = originSmi.body[i + matches[k]].start
                        ,   syncType = targetRange[k].syncType
                        ,   text = targetRange[k].text
                        });
                    else
                        targetSmi.body.Add(new Smi()
                        {   start = targetRange[k].start + shiftTime
                        ,   syncType = targetRange[k].syncType
                        ,   text = targetRange[k].text
                        });
                }

                for (int k = i + shiftIndex; k < originSmi.body.Count; k++)
                {
                    targetSmi.body.Add(originSmi.body[k]);
                }

                StreamWriter sw = null;
                try
                {
                    // 원본 파일의 인코딩대로 저장
                    sw = new StreamWriter(file, false, encoding);
                    sw.Write(targetSmi.ToTxt());
                    success++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    sw?.Close();
                }

            }

            string msg = "파일 " + files.Length + "개 중 " + success + "개의 작업이 완료됐습니다.";

            if (success > 0 && hasNewFrameSync)
            {
                msg += "\n화면 싱크를 조정할 부분이 있습니다.";
            }

            if (skips.Count > 0)
            {
                msg += "\n\n제외 파일:";
                foreach (string file in skips)
                {
                    msg += "\n" + file;
                }
            }

            Script("alert", new object[] { msg });
        }

        #region 파일
        public void AddFilesByDrag()
        {
            foreach (string file in droppedFiles)
            {
                GetFilesWithSubDir(file);
            }
        }
        public void GetFilesWithSubDir(string file)
        {
            if (Directory.Exists(file))
            {
                DirectoryInfo dir = new DirectoryInfo(file);
                DirectoryInfo[] subDirs = dir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                {
                    GetFilesWithSubDir(subDir.FullName);
                }
                FileInfo[] subFiles = dir.GetFiles();
                foreach (FileInfo subFile in subFiles)
                {
                    Script("addFile", new object[] { subFile.FullName });
                }
            }
            else
            {
                Script("addFile", new object[] { file });
            }
        }
        #endregion
    }
}
